using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
    public class ChangeUserPasswordViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [StringLength(100, ErrorMessage = "{0} deve ter pelo menos {2} e no máximo {1} letras.", MinimumLength = 6)]
        [Remote("ValidatePassword", "ChangeUserPassword",
            AdditionalFields = ViewModelConstants.AntiForgeryToken + "," + nameof(UserId), HttpMethod = "POST")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "(*)")]
        [DataType(DataType.Password)]
        [Display(Name = "Repita a nova senha")]
        [Compare(nameof(NewPassword), ErrorMessage = "As senhas inseridas não correspondem")]
        public string ConfirmPassword { get; set; }

        [HiddenInput]
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}