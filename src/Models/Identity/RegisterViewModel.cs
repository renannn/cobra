using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Nome do usuário")]
        [Remote("ValidateUsername", "Register", AdditionalFields = nameof(Email) + "," + ViewModelConstants.AntiForgeryToken, HttpMethod = "POST")]
        [RegularExpression("^[a-zA-Z_]*$", ErrorMessage = "Por favor, use apenas letras.")]
        public string Username { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "(*)")]
        [StringLength(450)]
        [RegularExpression("^[a-zA-Z_]*$", ErrorMessage = "Por favor, use apenas letras")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "(*)")]
        [StringLength(450)]
        [RegularExpression("^[a-zA-Z_]*$", ErrorMessage = "Por favor, use apenas letras")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Remote("ValidateUsername", "Register", AdditionalFields = nameof(Username) + "," + ViewModelConstants.AntiForgeryToken, HttpMethod = "POST")]
        [EmailAddress(ErrorMessage = "Por favor insira um endereço de e-mail válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "(*)")]
        [StringLength(100, ErrorMessage = "{0} deve ter pelo menos {2} e no máximo {1} letras.", MinimumLength = 6)]
        [Remote("ValidatePassword", "Register",
            AdditionalFields = nameof(Username) + "," + ViewModelConstants.AntiForgeryToken, HttpMethod = "POST")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "(*)")]
        [DataType(DataType.Password)]
        [Display(Name = "Repita a senha")]
        [Compare(nameof(Password), ErrorMessage = "As senhas inseridas não correspondem")]
        public string ConfirmPassword { get; set; }
    }
}