using Cobra.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Administration
{
    public class Role : IdentityRole<Guid>, IAuditableEntity, IHasId<Guid>, IHasName, IHasDescription, IHasCreationDate
    {
        #region Constructors

        public Role() : base() { }

        public Role(string name) : base(name) { }

        public Role(string name, string description)
            : this(name)
        {
            Description = description;
        }

        #endregion

        public string Description { get; set; }
        public virtual List<UserRole> Users { get; set; } = new();
        public virtual List<RoleClaim> Claims { get; set; } = new();
        public DateTime? CreatedDateTime { get; set; }
        public bool IsDisabled { get; set; }
    }
}
