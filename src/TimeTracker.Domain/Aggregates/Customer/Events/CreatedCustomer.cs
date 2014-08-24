using TimeTracker.Domain.Infrastructure;

namespace TimeTracker.Domain.Aggregates.Customer.Events
{
    public class CreatedCustomer : IDomainEvent
    {
        public string Name { get; private set; }
    }
}