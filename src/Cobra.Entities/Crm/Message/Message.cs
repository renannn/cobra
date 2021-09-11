using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Crm
{
    public abstract class Message : BaseEntity, IHasId<int>, IHasValue<string>, IHasCreationDate
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
