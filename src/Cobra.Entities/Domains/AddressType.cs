using Cobra.Entities.Administration;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Domains
{
    public class AddressType : BaseEntity, IHasId<short>, IHasName, IHasDescription, IHasCreationDate
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public virtual List<Address> Addresses { get; set; } = new();
    }
}
