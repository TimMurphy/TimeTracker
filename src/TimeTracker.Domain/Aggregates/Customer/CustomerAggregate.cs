using System.Collections.Generic;
using TimeTracker.Domain.Aggregates.Customer.Commands;
using TimeTracker.Domain.Aggregates.Customer.Events;
using TimeTracker.Domain.Aggregates.Customer.Exceptions;
using TimeTracker.Domain.Aggregates.Customer.Views;
using TimeTracker.Domain.Infrastructure;

namespace TimeTracker.Domain.Aggregates.Customer
{
    public class CustomerAggregate
    {
        private readonly ICustomerViewRepository CustomerViewRepository;

        public CustomerAggregate(ICustomerViewRepository customerViewRepository)
        {
            CustomerViewRepository = customerViewRepository;
        }

        public string Name { get; private set; }

        public IEnumerable<IDomainEvent> Receive(CreateCustomer command)
        {
            var customerId = CustomerViewRepository.FindCustomerIdByName(command.Name);

            if (customerId != null)
            {
                throw new DuplicateCustomerNameException(command);
            }

            yield return command.MapTo<CreatedCustomer>();
        }

        protected void Apply(CreatedCustomer @event)
        {
            Name = @event.Name;
        }
    }
}