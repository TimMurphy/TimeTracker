using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public class EventQueue : IEventQueue
    {
        public Task AddAsync(IEnumerable<IEvent> events)
        {
            throw new NotImplementedException();
        }

        public Task ProcessAsync()
        {
            throw new NotImplementedException();
        }
    }
}