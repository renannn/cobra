using System;
using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
	public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "(*)")]
        [StringLength(100, ErrorMessage = "{0} deve ter pelo menos {2} e no máximo {1} letras.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "(*)")]
        [DataType(DataType.Password)]
        [Display(Name = "Repita a nova senha")]
        [Compare(nameof(NewPassword), ErrorMessage = "As senhas inseridas não correspondem")]
        public string ConfirmPassword { get; set; }

        public DateTime? LastUserPasswordChangeDate { get; set; }
    }
}