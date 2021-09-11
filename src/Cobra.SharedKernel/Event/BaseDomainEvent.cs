using Cobra.SharedKernel.Interfaces;
using MediatR;
using System;

namespace Cobra.SharedKernel.Event
{
    public abstract class BaseDomainEvent : INotification, IBaseDomainEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.Now;
    }
}