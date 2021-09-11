using Cobra.Entities.Administration;

namespace Cobra.Models.Identity.Emails
{
    public class ChangePasswordNotificationViewModel : EmailsBase
    {
        public User User { set; get; }
    }
}