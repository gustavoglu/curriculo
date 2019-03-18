using Curriculo.Domain.Commands.Products;
using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Notifications;
using Curriculo.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curriculo.Services.Api.Controllers
{
    [AllowAnonymous]
    public class ProductController : BaseController
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository,IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get(int? page,int? limit)
        {
            return Response(_repository.GetAllActive(page, limit));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Response(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]AddProductCommand command)
        {
            SendCommand(command);
            return Response();
        }

        [HttpPut]
        public IActionResult Put([FromBody]UpdateProductCommand command)
        {
            SendCommand(command);
            return Response();
        }

        [HttpDelete("{id}")]
        public IActionResult Post(string id)
        {
            SendCommand(new DeleteProductCommand() { Id = id});
            return Response();
        }

    }
}
