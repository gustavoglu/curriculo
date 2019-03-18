using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Commands;
using Curriculo.Domain.Core.Notifications;
using Curriculo.Domain.Interfaces;
using MediatR;


namespace Studios.Project.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        private readonly IUnitOfWork _uow;

        public CommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IUnitOfWork uow)
        {
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
            _uow = uow;
        }

        protected bool CommandIsValid(Command command)
        {
            if (command.IsValid()) return true;
            NotifyValidationErrors(command);
            return false;
        }

        public bool HasNotifications() => _notifications.HasNotifications();

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
