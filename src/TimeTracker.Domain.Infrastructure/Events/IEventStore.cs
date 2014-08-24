using System;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public interface IEventStore
    {
        TAggregate Get<TAggregate>(Guid aggregateId);
    }
}