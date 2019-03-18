using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Notifications;
using Curriculo.Infra.Identity.Interfaces;
using Curriculo.Infra.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Curriculo.Infra.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMediatorHandler _bus;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IMediatorHandler bus)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _bus = bus;
        }

        public void Dispose()
        {
            _userManager.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task ChangePassword(string userId,string newPassword, string oldPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                SendNotification("User not found");
                return;
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded) return;
            SendNotificationsIdentityErrors(result);
        }

        public async Task ChangeUserName(string userId, string newUserName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                SendNotification("User not found");
                return;
            }

            var result = await _userManager.SetUserNameAsync(user, newUserName);
            if (result.Succeeded) return;
            SendNotificationsIdentityErrors(result);
        }

        public async Task Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded) return;
            SendNotification("UserName or Password Incorrect");
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task Register(string username, string password, string fullName = null, string email = null)
        {
            User user = new User() { UserName = username, FullName = fullName, Email = email ?? $"{username}@email.com" };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded) return;
            SendNotificationsIdentityErrors(result);
        }

        private void SendNotificationsIdentityErrors(IdentityResult result)
        {
            if (result.Succeeded) return;
            result.Errors.ToList().ForEach(e => _bus.RaiseEvent(new DomainNotification("UserService", e.Description)));
        }

        private void SendNotification(string value)
        {
            _bus.RaiseEvent(new DomainNotification("UserService", value));
        }
    }
}
