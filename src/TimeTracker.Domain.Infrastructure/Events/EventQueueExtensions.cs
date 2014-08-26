using System.Collections.Generic;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public static class EventQueueExtensions
    {
        public static void Add(this IEventQueue eventQueue, IEnumerable<IEvent> events)
        {
            eventQueue.AddAsync(events).Wait();
        }

        public static void Process(this IEventQueue eventQueue)
        {
            eventQueue.ProcessAsync().Wait();
        }
    }
}
