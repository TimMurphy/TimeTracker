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

        [Given(@"I a collection of events")]
        public void Given_I_A_CollectionOfEvents()
        {
            Events = new[] {new DummyEvent(), new DummyEvent()};
        }

        [When(@"I call AddAsync\(events\)")]
        public void WhenICallAddAsyncEvents()
        {
            EventQueue.Add(Events);
        }

        [Then(@"the events are added to the queue")]
        public void ThenTheEventsAreAddedToTheQueue()
        {
            EventQueue.Queue.ShouldAllBeEquivalentTo(Events);
        }
    }
}
