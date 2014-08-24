using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure
{
    public interface IQueue
    {
        void Process();
        Task ProcessAsync();
    }
}