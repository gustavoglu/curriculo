using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Curriculo.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        public List<DomainNotification> Notifications;
        public DomainNotificationHandler()
        {
            Notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications() => Notifications;
        public bool HasNotifications() => Notifications.Any();

        public void Dispose() => Notifications = new List<DomainNotification>();

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            Notifications.Add(notification);
            return Task.CompletedTask;
        }
    }
}
