using MediatR;

namespace Curriculo.Domain.Core.Events
{
    public abstract class Message : IRequest
    {
        public string MessageType { get; set; }
        public string AggregateId { get; set; }

        public Message()
        {
            MessageType = this.GetType().Name;
        }
    }
}
