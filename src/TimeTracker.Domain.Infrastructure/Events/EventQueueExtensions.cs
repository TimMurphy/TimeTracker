namespace TimeTracker.Domain.Infrastructure.Events
{
    public static class EventQueueExtensions
    {
        public static void Process(this IEventQueue eventQueue)
        {
            eventQueue.ProcessAsync().Wait();
        }
    }
}
