using Cobra.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Cobra.Entities.Administration
{
    public class UserRole : IdentityUserRole<Guid>, IAuditableEntity, IBaseEntity, IAggregateRoot
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
