using System;

namespace TimeTracker.Domain.Infrastructure
{
    public class EventStore : IEventStore
    {
        public TAggregate Get<TAggregate>(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}