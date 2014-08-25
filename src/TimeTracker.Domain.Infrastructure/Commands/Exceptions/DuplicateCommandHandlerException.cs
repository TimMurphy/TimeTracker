using System;

namespace TimeTracker.Domain.Infrastructure.Commands.Exceptions
{
    public class DuplicateCommandHandlerException : Exception
    {
        public DuplicateCommandHandlerException(Type commandType)
            : base(string.Format("Cannot register {0} command handler multiple times.", commandType))
        {
        }
    }
}