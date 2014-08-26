using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.UnitTests.Support.Fakes
{
    public class FakeEventQueue : IEventQueue
    {
        private readonly List<IEvent> AddedEventsField= new List<IEvent>();

        public Task AddAsync(IEnumerable<IEvent> events)
        {
            return Task.Run(() => AddedEventsField.AddRange(events));
        }

        public Task ProcessAsync()
        {
            throw new System.NotImplementedException();
        }

        public void RegisterEventHandler(Action<IEvent> eventHandler)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEvent> AddedEvents { get { return AddedEventsField; } }
    }
}