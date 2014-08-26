using System;
using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.Domain.Aggregates.Customer.Events
{
    public class CreatedCustomer : IEvent
    {
        public CreatedCustomer(Guid aggregateId, string name)
        {
            AggregateId = aggregateId;
            Name = name;
        }

        public Guid AggregateId { get; private set; }
        public string Name { get; private set; }
    }
}