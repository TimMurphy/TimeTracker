using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure.Commands
{
    public interface ICommandBus
    {
        Task SendAsync(ICommand command);
    }
}