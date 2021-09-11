using Cobra.Entities.Domains;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Crm
{
    public class ModelPrice : BaseEntity, IHasId<int>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Condition Condition { get; set; }
        public int ConditionId { get; set; }
        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }
        public Decimal MinimalValue { get; set; }
        public Decimal MaximalValue { get; set; }
        public Decimal DisplayValue { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
