using Microsoft.AspNetCore.Identity;
using System;

namespace Cobra.Entities.Administration
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual Role Role { get; set; }
    }
}
