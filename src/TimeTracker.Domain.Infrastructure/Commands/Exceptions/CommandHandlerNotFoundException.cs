using System;

namespace TimeTracker.Domain.Infrastructure.Commands.Exceptions
{
    public class CommandHandlerNotFoundException : Exception
    {
        public CommandHandlerNotFoundException(Type commandType)
            : base(string.Format("Cannot find command handler for {0} command.", commandType))
        {
        }
    }
}