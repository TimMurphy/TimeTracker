using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Infrastructure.Support;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public class EventQueue : IEventQueue
    {
        internal readonly Queue<IEvent> Queue = new Queue<IEvent>();

        public Task AddAsync(IEnumerable<IEvent> events)
        {
            return Task.Run(() => Queue.Enqueue(events));
        }

        public Task ProcessAsync()
        {
            throw new NotImplementedException();
        }
    }
}