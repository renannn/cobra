using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [EmailAddress(ErrorMessage = "Por favor insira um endereço de e-mail válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "(*)")]
        [StringLength(100, ErrorMessage = "{0} deve ter pelo menos {2} e no máximo {1} letras.", MinimumLength = 6)]
        [Remote("ValidatePassword", "ForgotPassword",
            AdditionalFields = nameof(Email) + "," + ViewModelConstants.AntiForgeryToken, HttpMethod = "POST")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "(*)")]
        [DataType(DataType.Password)]
        [Display(Name = "Repita a nova senha")]
        [Compare(nameof(Password), ErrorMessage = "As senhas inseridas não correspondem")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}