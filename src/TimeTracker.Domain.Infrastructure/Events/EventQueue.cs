using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public class EventQueue : IEventQueue
    {
        public void Process()
        {
            throw new System.NotImplementedException();
        }

        public Task ProcessAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}