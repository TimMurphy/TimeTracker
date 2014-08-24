using System;
using TimeTracker.Domain.Aggregates.Customer.Events;

namespace TimeTracker.Domain.Aggregates.Customer.Views
{
    public class CustomerView
    {
        public void Receive(CreatedCustomer @event)
        {
            throw new NotImplementedException();
        }
    }
}