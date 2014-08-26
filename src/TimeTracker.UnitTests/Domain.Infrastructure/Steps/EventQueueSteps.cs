using System.Collections.Generic;
using FluentAssertions;
using TechTalk.SpecFlow;
using TimeTracker.Domain.Infrastructure.Events;
using TimeTracker.UnitTests.Support.Dummies;
using TimeTracker.UnitTests.Support.Fakes;

namespace TimeTracker.UnitTests.Domain.Infrastructure.Steps
{
    [Binding]
    public class EventQueueSteps
    {
        private EventQueue EventQueue;
        private DummyEvent[] Events;
        private readonly IList<IEvent> PublishedEvents = new List<IEvent>();
        private FakeEventStore EventStore;
        private int EventsAddedToEventStoreBeforeEventHandler;

        [Given(@"an EventQueue")]
        public void GivenAnEventQueue()
        {
            EventStore = new FakeEventStore();
            EventQueue = new EventQueue(EventStore);
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
            EventQueue.Add(Events);
        }

        [Given(@"an event handler has been registered")]
        public void GivenAnEventHandlerHasBeenRegistered()
        {
            EventQueue.RegisterEventHandler(@event =>
            {
                EventsAddedToEventStoreBeforeEventHandler = EventStore.Events.Count;
                PublishedEvents.Add(@event);
            });
        }

        [When(@"ProcessAsync\(\) is called")]
        public void WhenProcessAsyncIsCalled()
        {
            EventQueue.ProcessAsync().Wait();
        }

        [Then(@"events are added to the event store")]
        public void ThenEventsAreAddedToTheEventStore()
        {
            EventStore.Events.ShouldAllBeEquivalentTo(Events);
        }

        [Then(@"registered event handler is called after the events have been added to the event store")]
        public void ThenRegisteredEventHandlerIsCalledAfterTheEventsHaveBeenAddedToTheEventStore()
        {
            EventsAddedToEventStoreBeforeEventHandler.Should().Be(Events.Length);
            PublishedEvents.ShouldAllBeEquivalentTo(Events);
        }
    }
}