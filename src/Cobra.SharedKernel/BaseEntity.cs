using Cobra.SharedKernel.Event;
using Cobra.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace Cobra.SharedKernel
{
    public abstract class BaseEntity : IBaseEntity
    {
        public List<BaseDomainEvent> Events = new();
    }
}