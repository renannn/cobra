using System.ComponentModel.DataAnnotations;

namespace Cobra.BuyList.Admin.Models
{
    public class LoginForm
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
