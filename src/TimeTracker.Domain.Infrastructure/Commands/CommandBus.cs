using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure.Commands
{
    public class CommandBus : ICommandBus
    {
        public void Send(ICommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task SendAsync(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}