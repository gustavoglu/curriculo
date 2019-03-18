using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Commands;
using Curriculo.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Curriculo.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public BaseController(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected new IActionResult Response(object obj = null)
        {
            if (!ModelState.IsValid) AddErrorsModalStateInNotifications();

            bool success = (!HasNotification() && ModelState.IsValid);

            var response = new { success, data = success ? obj : NotificationList() };

            if (response.success) return Ok(response);

            return BadRequest(response);
        }

        private object NotificationList()
        {
            return from n in _notifications.GetNotifications()
                   select new { key = n.Key, value = n.Value };

        }

        private void AddErrorsModalStateInNotifications()
        {
            if (ModelState.IsValid) return;

            var erros = from values in ModelState.Values
                        from modelError in values.Errors
                        select modelError.ErrorMessage;

            erros.ToList().ForEach(e => SendNotification("ModelState", e));
        }

        protected bool HasNotification()
        {
            return _notifications.HasNotifications();
        }

        protected void SendNotification(string key, string value)
        {
            _bus.RaiseEvent(new DomainNotification(key, value));
        }

        protected void SendCommand<T>(T command) where T : Command
        {
            if (command == null) command = (T)Activator.CreateInstance(typeof(T));
            _bus.SendCommand(command);
        }
    }
}
