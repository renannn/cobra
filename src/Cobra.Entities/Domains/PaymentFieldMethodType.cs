using Cobra.Entities.Crm;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Domains
{
    public class PaymentFieldMethodType : BaseEntity, IHasId<int>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Validation { get; set; }
        public string Mask { get; set; }
        public int MaxLenght { get; set; }
        public bool IsRequired { get; set; }
        public virtual List<PaymentValueField> PaymentValuesFields { get; set; } = new();
        public DateTime? CreatedDateTime { get; set; }

        public virtual PaymentMethodType PaymentMethodType {  get; set; } 
        public short PaymentMethodTypeId {  get; set; } 
    }
}
