using System;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IBaseDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}