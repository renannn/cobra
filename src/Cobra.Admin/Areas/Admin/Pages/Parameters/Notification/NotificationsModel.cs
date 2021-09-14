using System.ComponentModel.DataAnnotations;

namespace Cobra.Admin.Areas.Admin.Pages.Parameters.Notification
{
    public class NotificationsModel
    {
        [Display(Name = "Notificações Ativadas")]
        public bool IsEnabled { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Google Play MerchantName")]
        public string MerchantName { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Google Play MerchantId")]
        public string MerchantId { get; set; }
    }
}
