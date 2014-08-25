using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Infrastructure.Commands.Exceptions;
using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.Domain.Infrastructure.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IEventQueue EventQueue;
        internal readonly ConcurrentDictionary<Type, Func<ICommand, Task<IEnumerable<IEvent>>>> CommandHandlers = new ConcurrentDictionary<Type, Func<ICommand, Task<IEnumerable<IEvent>>>>();

        public CommandBus(IEventQueue eventQueue)
        {
            EventQueue = eventQueue;
        }
        
        public async Task SendAsync(ICommand command)
        {
            var commandHandler = GetRegisteredCommandHandler(command.GetType());
            var events = await commandHandler(command);

#pragma warning disable 4014
            EventQueue.AddAsync(events);
#pragma warning restore 4014
        }

        private Func<ICommand, Task<IEnumerable<IEvent>>> GetRegisteredCommandHandler(Type commandType)
        {
            Func<ICommand, Task<IEnumerable<IEvent>>> commandHandler;

            if (CommandHandlers.TryGetValue(commandType, out commandHandler))
            {
                return commandHandler;
            }

            throw new CommandHandlerNotFoundException(commandType);
        }

        public void RegisterCommandHandler<TCommand>(Func<TCommand, Task<IEnumerable<IEvent>>> commandHandler) where TCommand : ICommand
        {
            Func<ICommand, Task<IEnumerable<IEvent>>> cmdHandler = command => commandHandler((TCommand)command);

            if (cmdHandler == null)
            {
                throw new ArgumentException("Cannot convert commandHandler to Func<ICommand, Task<IEnumerable<IEvent>>>");
            }

            RegisterCommandHandler(typeof(TCommand), cmdHandler);
        }

        private void RegisterCommandHandler(Type commandType, Func<ICommand, Task<IEnumerable<IEvent>>> commandHandler)
        {
            if (CommandHandlers.TryAdd(commandType, commandHandler))
            {
                return;
            }

            throw new DuplicateCommandHandlerException(commandType);
        }
    }
}