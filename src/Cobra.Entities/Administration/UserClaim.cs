using Microsoft.AspNetCore.Identity;
using System;

namespace Cobra.Entities.Administration
{
    public class UserClaim : IdentityUserClaim<Guid>
    {
        public virtual User User { get; set; }
    }
}
