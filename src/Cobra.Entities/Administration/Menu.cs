using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Administration
{
    public class Menu : BaseEntity, IAuditableEntity, IHasId<Guid>, IHasName, IHasDescription, IHasCreationDate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string Path { get; set; }
        public virtual List<SubMenu> SubMenus { get; set; } = new();
        public virtual Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
