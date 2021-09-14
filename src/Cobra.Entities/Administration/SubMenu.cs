using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Administration
{
    public class SubMenu : BaseEntity, IAuditableEntity, IHasId<Guid>, IHasName, IHasDescription, IHasCreationDate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string Path { get; set; }
        public virtual Menu Menu { get; set; }
        public Guid MenuId { get; set; }
    }
}
