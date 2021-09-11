﻿using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Crm
{
    public class PaymentValueField : BaseEntity, IHasId<long>, IHasValue<string>, IAuditableEntity, IHasCreationDate
    {
        public long Id { get; set; }
        public string Value { get; set; }
        //public virtual FieldPaymentMethodType FieldPaymentMethodType { get; set; }
        public int FieldPaymentMethodTypeID { get; set; }
        //public virtual PaymentMethod PaymentMethod { get; set; }
        public Guid PaymentMethodId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
