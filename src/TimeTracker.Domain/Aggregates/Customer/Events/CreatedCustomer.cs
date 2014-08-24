using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.Domain.Aggregates.Customer.Events
{
    public class CreatedCustomer : IEvent
    {
        public string Name { get; private set; }
    }
}