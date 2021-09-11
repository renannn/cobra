using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [EmailAddress(ErrorMessage = "Por favor insira um endereço de e-mail válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}