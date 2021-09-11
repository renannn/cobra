using Microsoft.AspNetCore.Identity;
using System;

namespace Cobra.Entities.Administration
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public virtual User User { get; set; }
    }
}
