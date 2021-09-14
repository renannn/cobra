using System.ComponentModel.DataAnnotations;

namespace Cobra.Admin.Areas.Admin.Pages.Parameters.GeneralSettings;

public class GeneralSettingsModel
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Termos de Uso")]
        public string TermsOfUse { get; set; }
    }
