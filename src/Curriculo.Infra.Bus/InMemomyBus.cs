using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Commands;
using Curriculo.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace Curriculo.Infra.Bus
{
    public class InMemomyBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public InMemomyBus(IMediator mediator)
        {
            _mediator = mediator;
        }
        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

    
    }
}
