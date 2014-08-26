using System;
using System.Collections.Generic;
using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.UnitTests.Support.Fakes
{
    internal class FakeEventStore : IEventStore
    {
        internal readonly IList<IEvent> Events = new List<IEvent>();

        public TAggregate Get<TAggregate>(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}
