using Cobra.Entities.Crm;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Domains
{
    public class Condition : BaseEntity, IHasId<int>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<ModelPrice> ModelPrices { get; set; } = new();
        public virtual List<BuyListItem> ItensBuyList { get; set; } = new();
        public DateTime? CreatedDateTime { get; set; }
    }
}
