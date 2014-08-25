using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.Domain.Infrastructure.Commands
{
    public interface ICommandBus
    {
        Task SendAsync(ICommand command);
        void RegisterCommandHandler<TCommand>(Func<TCommand, Task<IEnumerable<IEvent>>> action) where TCommand : ICommand;
    }
}