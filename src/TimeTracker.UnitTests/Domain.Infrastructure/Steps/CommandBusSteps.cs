using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TimeTracker.Domain.Infrastructure.Commands;
using TimeTracker.Domain.Infrastructure.Commands.Exceptions;
using TimeTracker.Domain.Infrastructure.Events;
using TimeTracker.Domain.Infrastructure.Support;
using TimeTracker.UnitTests.Support.Fakes;

namespace TimeTracker.UnitTests.Domain.Infrastructure.Steps
{
    [Binding]
    public class CommandBusSteps
    {
        private readonly FakeCommand Command;
        private readonly CommandBus CommandBus;
        private readonly FakeEventQueue EventQueue;
        private readonly IList<ICommand> HandledCommands = new List<ICommand>();
        private readonly IList<IEvent> ReturnedEvents = new List<IEvent>();
        private Exception Exception;

        public CommandBusSteps()
        {
            EventQueue = new FakeEventQueue();
            Command = new FakeCommand();

            CommandBus = new CommandBus(EventQueue);
        }

        private Task<IEnumerable<IEvent>> HandleCommand(FakeCommand command)
        {
            var @event = new FakeEvent(command.AggregateId);

            HandledCommands.Add(command);
            ReturnedEvents.Add(@event);

            return Helper.Events(@event);
        }

        [When(@"SendAsync\(command\) is called")]
        public void WhenSendAsyncCommandIsCalled()
        {
            try
            {
                CommandBus.SendAsync(Command).Wait();
            }
            catch (Exception exception)
            {
                Exception = exception;
            }
        }

        [Then(@"the command is processed by registered command handler")]
        public void ThenTheCommandIsProcessedByARegisteredCommandHandler()
        {
            HandledCommands.ShouldAllBeEquivalentTo(HandledCommands);
        }

        [Then(@"the events returned by the command handler are added to the event queue")]
        public void ThenTheEventsReturnedByTheCommandHandlerAreAddedToTheEventQueue()
        {
            EventQueue.AddedEvents.ShouldAllBeEquivalentTo(ReturnedEvents);
        }

        private void RegisterCommandHandler(bool shouldThrowException = false)
        {
            try
            {
                CommandBus.RegisterCommandHandler<FakeCommand>(HandleCommand);
            }
            catch (Exception exception)
            {
                if (!shouldThrowException)
                {
                    throw;
                }

                Exception = exception;
            }
        }

        [Then(@"the command handler is added to list of command handlers")]
        public void ThenTheCommandHandlerIsAddedToListOfCommandHandlers()
        {
            CommandBus.CommandHandlers.ContainsKey(Command.GetType()).Should().BeTrue();
        }

        [When(@"RegisterCommandHandler\(commandHandler\) is called")]
        public void WhenRegisterCommandHandlerIsCalled()
        {
            RegisterCommandHandler();
        }

        [Given(@"command handler has been registered")]
        public void GivenACommandHandlerHasBeenRegistered()
        {
            RegisterCommandHandler();
        }

        [When(@"RegisterCommandHandler\(commandHandler\) is called for a second time")]
        public void WhenRegisterCommandHandlerIsCalledForASecondTime()
        {
            RegisterCommandHandler(true);
        }

        [Then(@"DuplicateCommandHandlerException is thrown")]
        public void ThenDuplicateCommandHandlerExceptionIsThrown()
        {
            Exception.Should().BeOfType<DuplicateCommandHandlerException>();
        }

        [Then(@"CommandHandlerNotFoundException is thrown")]
        public void ThenCommandHandlerNotFoundExceptionIsThrown()
        {
            Exception.Should().BeOfType<AggregateException>();
            Exception.InnerException.Should().BeOfType<CommandHandlerNotFoundException>();
        }
    }
}