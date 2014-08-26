using System;
using TimeTracker.Domain.Aggregates.Customer.Events;

namespace TimeTracker.Domain.Aggregates.Customer.Views
{
    public class CustomerView
    {
        public void HandleEvent(CreatedCustomer @event)
        {
            throw new NotImplementedException();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}