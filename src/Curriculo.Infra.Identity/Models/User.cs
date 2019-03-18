using Microsoft.AspNetCore.Identity;

namespace Curriculo.Infra.Identity.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
