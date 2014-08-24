using System.Threading.Tasks;
using TimeTracker.Domain.Infrastructure;

namespace TimeTracker.UnitTests.Support
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