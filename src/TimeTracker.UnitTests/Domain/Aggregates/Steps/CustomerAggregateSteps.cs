using System;
using FluentAssertions;
using TechTalk.SpecFlow;
using TimeTracker.Domain.Aggregates.Customer;
using TimeTracker.Domain.Aggregates.Customer.Commands;
using TimeTracker.Domain.Aggregates.Customer.Views;
using TimeTracker.Domain.Infrastructure;

namespace TimeTracker.UnitTests.Domain.Aggregates.Steps
{
    [Binding]
    public class CustomerAggregateSteps
    {
        private readonly ICommandBus Bus;
        private readonly IQueue Queue;
        private readonly IEventStore EventStore;
        private readonly ICustomerViewRepository CustomerViewRepository;
        private CreateCustomer Command;

        public CustomerAggregateSteps(ICommandBus bus, IQueue queue, IEventStore eventStore, ICustomerViewRepository customerViewRepository)
        {
            Bus = bus;
            Queue = queue;
            EventStore = eventStore;
            CustomerViewRepository = customerViewRepository;
        }

        [When(@"I send a CreateCustomer command")]
        public void WhenISendACreateCustomerCommand()
        {
            Command = SendCommandAndProcessQueue(new CreateCustomer(Guid.NewGuid(), "Dummy Customer"));
        }

        private TCommand SendCommandAndProcessQueue<TCommand>(TCommand command) where TCommand : ICommand
        {
            Bus.Send(Command);
            Queue.Process();

            return command;
        }

        [Then(@"CustomerAggregate is created")]
        public void ThenCustomerAggregateIsCreated()
        {
            var customer = EventStore.Get<CustomerAggregate>(Command.AggregateId);

            customer.Name.Should().Be(Command.Name);
        }

        [Then(@"CustomerView is created")]
        public void ThenCustomerViewIsCreated()
        {
            var customer = CustomerViewRepository.GetCustomer(Command.AggregateId);

            customer.Name.Should().Be(Command.Name);
        }
    }
}
