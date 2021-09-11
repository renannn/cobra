using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Domains
{
    public class Bank : BaseEntity, IHasId<short>, IHasName, IHasCreationDate
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
