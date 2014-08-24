using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure
{
    public interface ICommandBus
    {
        void Send(ICommand command);
        Task SendAsync(ICommand command);
    }
}