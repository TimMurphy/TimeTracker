using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Aggregates.Customer.Commands;
using TimeTracker.Domain.Aggregates.Customer.Events;
using TimeTracker.Domain.Aggregates.Customer.Exceptions;
using TimeTracker.Domain.Aggregates.Customer.Views;
using TimeTracker.Domain.Infrastructure.Events;
using TimeTracker.Domain.Infrastructure.Mapping;
using TimeTracker.Domain.Infrastructure.Support;

namespace TimeTracker.Domain.Aggregates.Customer
{
    public class CustomerCommandHandlers
    {
        private readonly ICustomerViewRepository CustomerViewRepository;

        public CustomerCommandHandlers(ICustomerViewRepository customerViewRepository)
        {
            CustomerViewRepository = customerViewRepository;
        }

        public Task<IEnumerable<IEvent>> HandleCommand(CreateCustomer command)
        {
            var customerId = CustomerViewRepository.FindCustomerIdByName(command.Name);

            if (customerId != null)
            {
                throw new DuplicateCustomerNameException(command);
            }

            return Helper.Events(command.MapTo<CreatedCustomer>());
        }
    }
}
