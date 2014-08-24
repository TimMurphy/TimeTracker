using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure
{
    public interface IEventQueue
    {
        void Process();
        Task ProcessAsync();
    }
}