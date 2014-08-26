using TechTalk.SpecFlow;

namespace TimeTracker.UnitTests.Domain.Infrastructure.Steps
{
    [Binding]
    public class EventQueueSteps
    {
        [Given(@"an EventQueue")]
        public void GivenAnEventQueue()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I a collection of events")]
        public void Given_I_A_CollectionOfEvents()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call AddAsync\(events\)")]
        public void WhenICallAddAsyncEvents()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the events are added to the queue")]
        public void ThenTheEventsAreAddedToTheQueue()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
