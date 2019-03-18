using Curriculo.Domain.Commands.Products;
using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Notifications;
using Curriculo.Domain.Interfaces;
using Curriculo.Domain.Interfaces.Repositories;
using Curriculo.Domain.Models;
using MediatR;
using Studios.Project.Domain.CommandHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Curriculo.Domain.Models.Product;

namespace Curriculo.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler, IRequestHandler<AddProductCommand>, IRequestHandler<UpdateProductCommand>, IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;
        public ProductCommandHandler(IProductRepository repository,IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IUnitOfWork uow) : base(bus, notifications, uow)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;
            var entity = new Product(request.Name, request.ProductTypeId, request.Description, request.Price);
            _repository.Add(entity);
            Commit();
            return Unit.Task;
        }

        public Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;
            var entity = ProductFactory.Full(request.Id,request.Name, request.ProductTypeId,request.CreateBy,request.CreateAt,request.UpdateBy,
                                                request.UpdateAt,request.DeleteBy,request.DeleteAt,request.IsDeleted,request.Description,request.Price);
            _repository.Update(entity);
            Commit();
            return Unit.Task;
        }

        public Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;
            _repository.Delete(request.Id);
            Commit();
            return Unit.Task;
        }
    }
}
