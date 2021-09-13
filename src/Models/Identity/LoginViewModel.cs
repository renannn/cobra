using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Manter conectado")]
        public bool RememberMe { get; set; }
    }
}