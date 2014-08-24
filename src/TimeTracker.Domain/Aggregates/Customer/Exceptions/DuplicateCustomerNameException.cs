using System;
using TimeTracker.Domain.Aggregates.Customer.Commands;
using TimeTracker.Domain.Infrastructure.Commands;

namespace TimeTracker.Domain.Aggregates.Customer.Exceptions
{
    public class DuplicateCustomerNameException : CommandException
    {
        public DuplicateCustomerNameException(CreateCustomer command)
        {
            throw new NotImplementedException();
        }
    }
}