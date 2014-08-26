using System;
using System.Linq;
using TimeTracker.Domain.Aggregates.Customer.Views;

namespace TimeTracker.UnitTests.Support.Fakes.Repositories
{
    public class FakeCustomerViewRepository : FakeRepository<CustomerView>, ICustomerViewRepository
    {
        public Guid? FindCustomerIdByName(string name)
        {
            var customer = Items.SingleOrDefault(c => c.Name == name);

            return customer == null ? (Guid?) null : customer.Id;
        }

        public CustomerView GetCustomer(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}