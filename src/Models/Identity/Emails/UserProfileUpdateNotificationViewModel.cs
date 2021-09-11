using Cobra.Entities.Administration;

namespace Cobra.Models.Identity.Emails
{
    public class UserProfileUpdateNotificationViewModel : EmailsBase
    {
        public User User { set; get; }
    }
}