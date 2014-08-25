using System;
using TimeTracker.Domain.Aggregates.Customer.Views;

namespace TimeTracker.UnitTests.Support.Fakes.Repositories
{
    public class FakeCustomerViewRepository : ICustomerViewRepository
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