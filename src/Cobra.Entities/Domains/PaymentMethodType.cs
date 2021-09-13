using Cobra.Entities.Crm;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Domains
{
    public class PaymentMethodType : BaseEntity, IHasId<short>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public virtual List<PaymentMethod> PaymentMethods { get; set; } = new();
    }
}
