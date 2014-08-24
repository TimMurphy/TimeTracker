using System;
using TimeTracker.Domain.Infrastructure;

namespace TimeTracker.UnitTests.Support
{
    public class EventStore : IEventStore
    {
        public TAggregate Get<TAggregate>(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}