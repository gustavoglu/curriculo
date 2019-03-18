using Curriculo.Domain.Commands.ProductTypes;
using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Notifications;
using Curriculo.Domain.Interfaces;
using Curriculo.Domain.Interfaces.Repositories;
using Curriculo.Domain.Models;
using MediatR;
using Studios.Project.Domain.CommandHandlers;
using System.Threading;
using System.Threading.Tasks;
using static Curriculo.Domain.Models.ProductType;

namespace Curriculo.Domain.CommandHandlers
{
    public class ProductTypeCommandHandler : CommandHandler, IRequestHandler<AddProductTypeCommand>, IRequestHandler<UpdateProductTypeCommand>, IRequestHandler<DeleteProductTypeCommand>
    {
        private readonly IProductTypeRepository _repository;
        public ProductTypeCommandHandler(IProductTypeRepository repository, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IUnitOfWork uow) : base(bus, notifications, uow)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(AddProductTypeCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;
            var entity = new ProductType(request.Name);
            _repository.Add(entity);
            Commit();
            return Unit.Task;
        }

        public Task<Unit> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;
            var entity = ProductTypeFactory.Full(request.Id, request.Name, request.CreateBy, request.CreateAt, request.UpdateBy,
                                                request.UpdateAt, request.DeleteBy, request.DeleteAt, request.IsDeleted);
            _repository.Update(entity);
            Commit();
            return Unit.Task;
        }

        public Task<Unit> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return Unit.Task;
            _repository.Delete(request.Id);
            Commit();
            return Unit.Task;
        }
    }
}
