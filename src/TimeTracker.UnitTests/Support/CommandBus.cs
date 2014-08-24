using System.Threading.Tasks;
using TimeTracker.Domain.Infrastructure;

namespace TimeTracker.UnitTests.Support
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