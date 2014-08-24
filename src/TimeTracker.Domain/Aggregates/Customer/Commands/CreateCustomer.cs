using TimeTracker.Domain.Infrastructure;

namespace TimeTracker.Domain.Aggregates.Customer.Commands
{
    public class CreateCustomer : IDomainCommand
    {
        public string Name { get; private set; }
    }
}