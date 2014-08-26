using System;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public interface IEvent
    {
        Guid AggregateId { get; }
    }
}