using Cobra.Entities.Administration;
using Cobra.Entities.Domains;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Crm
{
    public class PaymentMethod : BaseEntity, IHasId<Guid>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual PaymentMethodType PaymentMethodType { get; set; }
        public short PaymentMethodTypeId { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual Bank Bank {  get; set; }
        public short BankId { get; set;  }

        public virtual List<PaymentValueField> PaymentValuesFields { get; set; } = new();
    }
}
