using System;
using TechTalk.SpecFlow;

namespace TimeTracker.UnitTests.Domain.Infrastructure.Commands.Steps
{
    [Binding]
    public class CommandBusSteps
    {
        [When(@"SendAsync\(ICommand command\) is called")]
public void WhenSendAsyncICommandCommandIsCalled()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"the command is processed by a registered command handler")]
public void ThenTheCommandIsProcessedByARegisteredCommandHandler()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"the events returned by the command handler are added to the event queue")]
public void ThenTheEventsReturnedByTheCommandHandlerAreAddedToTheEventQueue()
{
    ScenarioContext.Current.Pending();
}
    }
}
