using System.ComponentModel.DataAnnotations;

namespace Curriculo.Infra.Application.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm Password is Required")]
        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
