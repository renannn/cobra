using Cobra.Entities.Domains;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Crm
{
    public class Model : BaseEntity, IHasId<Guid>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual List<ModelImage> Images { get; set; } = new();
        //public virtual List<ModelPrice> Prices { get; set; } = new();
        public virtual List<BuyListItem> ItensBuyList { get; set; } = new();
        public DateTime? CreatedDateTime { get; set; }
    }
}