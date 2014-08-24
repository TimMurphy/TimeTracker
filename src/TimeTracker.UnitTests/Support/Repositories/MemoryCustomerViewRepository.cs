using System;
using TimeTracker.Domain.Aggregates.Customer.Views;

namespace TimeTracker.UnitTests.Support.Repositories
{
    public class MemoryCustomerViewRepository : ICustomerViewRepository
    {
        public Guid FindCustomerIdByName(string name)
        {
            throw new NotImplementedException();
        }

        public CustomerView GetCustomer(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}