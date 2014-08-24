using System;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public class EventStore : IEventStore
    {
        public TAggregate Get<TAggregate>(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}