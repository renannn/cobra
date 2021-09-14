using Cobra.Entities.Crm;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Domains
{
    public class Bank : BaseEntity, IHasId<short>, IHasName, IHasCreationDate
    {
        public short Id { get; set; }
        public short Codigo { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public virtual List<PaymentMethod> PaymentMethods { get; set; } = new();
    }
}
