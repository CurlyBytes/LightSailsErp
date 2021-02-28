using MediatR;
using System;

namespace SharedKernel.Events
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}