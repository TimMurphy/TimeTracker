using System;
using FluentAssertions;
using TechTalk.SpecFlow;
using TimeTracker.Domain.Aggregates.Customer;
using TimeTracker.Domain.Aggregates.Customer.Commands;
using TimeTracker.Domain.Aggregates.Customer.Views;
using TimeTracker.Domain.Infrastructure.Commands;
using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.UnitTests.Domain.Aggregates.Steps
{
    [Binding]
    public class CustomerAggregateSteps
    {
        private readonly ICommandBus CommandBus;
        private readonly IEventQueue EventQueue;
        private readonly IEventStore EventStore;
        private readonly ICustomerViewRepository CustomerViewRepository;
        private readonly CustomerCommandHandlers CustomerCommandHandlers;
        private CreateCustomer Command;

        public CustomerAggregateSteps(ICommandBus commandBus, IEventQueue eventQueue, IEventStore eventStore, ICustomerViewRepository customerViewRepository, CustomerCommandHandlers customerCommandHandlers)
        {
            CommandBus = commandBus;
            EventQueue = eventQueue;
            EventStore = eventStore;
            CustomerViewRepository = customerViewRepository;
            CustomerCommandHandlers = customerCommandHandlers;
        }

        [Given(@"CreateCustomer command handler is registered with command bus")]
        public void GivenCreateCustomerCommandHandlerIsRegisteredWithCommandBus()
        {
            CommandBus.RegisterCommandHandler((CreateCustomer command) => CustomerCommandHandlers.HandleCommand(command));
        }
        
        [When(@"I send a CreateCustomer command")]
        public void WhenISendACreateCustomerCommand()
        {
            Command = SendCommandAndProcessQueue(new CreateCustomer(Guid.NewGuid(), "Dummy Customer"));
        }

        private TCommand SendCommandAndProcessQueue<TCommand>(TCommand command) where TCommand : ICommand
        {
            CommandBus.Send(command);
            EventQueue.Process();

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
