using System;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public abstract class EventBase : IEvent
    {
        protected EventBase(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public Guid AggregateId { get; private set; }
    }
}