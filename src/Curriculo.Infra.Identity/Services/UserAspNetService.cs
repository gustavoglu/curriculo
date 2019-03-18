using Curriculo.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Curriculo.Infra.Identity.Services
{
    public class UserAspNetService : IUserAspNet
    {
        private readonly IHttpContextAccessor _accessor;
        public UserAspNetService( IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public List<Claim> GetClaims()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated ? _accessor.HttpContext.User.Claims.ToList() : 
                                                                        new List<Claim>();
        }

        public string GetName()
        {
            return _accessor.HttpContext.User.Identity.Name;
        }

        public string GetUserId()
        {
            return _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
