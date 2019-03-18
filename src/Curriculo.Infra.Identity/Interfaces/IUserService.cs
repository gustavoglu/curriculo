using System;
using System.Threading.Tasks;

namespace Curriculo.Infra.Identity.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task Login(string username, string password);
        Task Logout();
        Task Register(string username, string password, string fullName = null, string email = null);
        Task ChangePassword(string userId, string newPassword, string oldPassword);
        Task ChangeUserName(string userId, string newUserName);
    }
}
