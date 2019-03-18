using Curriculo.Domain.Commands.ProductTypes;
using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Notifications;
using Curriculo.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curriculo.Services.Api.Controllers
{
    [AllowAnonymous]
    public class ProductTypeController : BaseController
    {
        private readonly IProductTypeRepository _repository;
        public ProductTypeController(IProductTypeRepository repository, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get(int? page, int? limit)
        {
            return Response(_repository.GetAllActive(page, limit));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Response(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]AddProductTypeCommand command)
        {
            SendCommand(command);
            return Response();
        }

        [HttpPut]
        public IActionResult Put([FromBody]UpdateProductTypeCommand command)
        {
            SendCommand(command);
            return Response();
        }

        [HttpDelete("{id}")]
        public IActionResult Post(string id)
        {
            SendCommand(new DeleteProductTypeCommand() { Id = id });
            return Response();
        }

    }
}
