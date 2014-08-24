using System;

namespace TimeTracker.Domain.Infrastructure.Commands
{
    public interface ICommand
    {
        Guid AggregateId { get; }
    }
}