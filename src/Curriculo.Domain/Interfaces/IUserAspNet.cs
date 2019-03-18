using System.Collections.Generic;
using System.Security.Claims;

namespace Curriculo.Domain.Interfaces
{
    public interface IUserAspNet
    {
        string GetName();
        string GetUserId();
        List<Claim> GetClaims();
        bool IsAuthenticated();
    }
}
