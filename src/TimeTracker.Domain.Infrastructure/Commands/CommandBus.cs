using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure.Commands
{
    public class CommandBus : ICommandBus
    {
        public Task SendAsync(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}