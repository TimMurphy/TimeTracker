using TimeTracker.Domain.Aggregates.Customer.Events;

namespace TimeTracker.Domain.Aggregates.Customer
{
    public class CustomerAggregate
    {
        public string Name { get; private set; }

        protected void ApplyEvents(CreatedCustomer @event)
        {
            Name = @event.Name;
        }
    }
}