using Cobra.Entities.Crm;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Domains
{
    public class Brand : BaseEntity, IHasId<int>, IHasName, IHasDescription, IAuditableEntity, IHasImage<BrandImage>, IHasCreationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Model> Models { get; set; } = new();
        public virtual List<BrandImage> Images { get; set; } = new();
        public DateTime? CreatedDateTime { get; set; }
    }
}
