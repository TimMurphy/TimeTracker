using System;

namespace TimeTracker.Domain.Infrastructure
{
    public interface IEventStore
    {
        TAggregate Get<TAggregate>(Guid aggregateId);
    }
}