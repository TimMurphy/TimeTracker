using System;
using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.UnitTests.Support.Dummies
{
    internal class DummyEvent : EventBase
    {
        internal DummyEvent()
            : this(Guid.NewGuid())
        {
        }

        internal DummyEvent(Guid aggregateId)
            : base(aggregateId)
        {
        }

    }
}