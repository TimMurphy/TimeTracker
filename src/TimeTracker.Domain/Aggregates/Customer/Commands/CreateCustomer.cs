using System;
using TimeTracker.Domain.Infrastructure;

namespace TimeTracker.Domain.Aggregates.Customer.Commands
{
    public class CreateCustomer : ICommand
    {
        public CreateCustomer(Guid aggregateId, string name)
        {
            AggregateId = aggregateId;
            Name = name;
        }

        public Guid AggregateId { get; private set; }
        public string Name { get; private set; }
    }
}