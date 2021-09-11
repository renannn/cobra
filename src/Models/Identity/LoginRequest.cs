using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Nome de usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}