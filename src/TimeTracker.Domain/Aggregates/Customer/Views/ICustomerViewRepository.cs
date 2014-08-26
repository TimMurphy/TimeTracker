using System;

namespace TimeTracker.Domain.Aggregates.Customer.Views
{
    public interface ICustomerViewRepository
    {
        Guid? FindCustomerIdByName(string name);
        CustomerView GetCustomer(Guid aggregateId);
    }
}