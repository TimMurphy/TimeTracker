using FluentAssertions;
using TechTalk.SpecFlow;
using TimeTracker.Domain.Infrastructure.Events;
using TimeTracker.UnitTests.Support.Dummies;

namespace TimeTracker.UnitTests.Domain.Infrastructure.Steps
{
    [Binding]
    public class EventQueueSteps
    {
        private EventQueue EventQueue;
        private DummyEvent[] Events;

        [Given(@"an EventQueue")]
        public void GivenAnEventQueue()
        {
            EventQueue = new EventQueue();
        }

        [Given(@"a collection of events")]
        public void GivenACollectionOfEvents()
        {
            Events = new[] {new DummyEvent(), new DummyEvent()};
        }

        [When(@"AddAsync\(events\) is called")]
        public void WhenAddAsyncEventsIsCalled()
        {
            EventQueue.Add(Events);
        }

        [Then(@"the events are added to the queue")]
        public void ThenTheEventsAreAddedToTheQueue()
        {
            EventQueue.Queue.ShouldAllBeEquivalentTo(Events);
        }

        [Given(@"the events are added to the queue")]
        public void GivenTheEventsAreAddedToTheQueue()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"an event handler has been registered")]
        public void GivenAnEventHandlerHasBeenRegistered()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"ProcessAsync\(\) is called")]
        public void WhenProcessAsyncIsCalled()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"EventStore\.SaveEvents\(events\) is called")]
        public void ThenEventStore_SaveEventsEventsIsCalled()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"registered event handler is called")]
        public void ThenRegisteredEventHandlerIsCalled()
        {
            ScenarioContext.Current.Pending();
        }
    }
}