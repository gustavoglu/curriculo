using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Notifications;
using Curriculo.Infra.Application.ViewModels.Identity;
using Curriculo.Infra.Identity.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Curriculo.Services.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService,IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return Response();
            await _userService.Register(model.UserName, model.Password, model.FullName, model.Email);
            return Response();

        }
    }
}
