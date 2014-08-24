using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public interface IEventQueue
    {
        void Process();
        Task ProcessAsync();
    }
}