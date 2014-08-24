using TimeTracker.Domain.ValueObjects;

namespace TimeTracker.Domain.Aggregates.Customer.Views
{
    public interface ICustomerViewRepository
    {
        Id FindCustomerIdByName(string name);
    }
}