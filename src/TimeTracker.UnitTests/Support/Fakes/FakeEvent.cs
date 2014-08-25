using System;
using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.UnitTests.Support.Fakes
{
    internal class FakeEvent : IEvent
    {
        public FakeEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public Guid AggregateId { get; private set; }
    }
}