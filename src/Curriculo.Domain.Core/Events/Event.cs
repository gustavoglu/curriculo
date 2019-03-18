using MediatR;
using System;

namespace Curriculo.Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; protected set; }
        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
