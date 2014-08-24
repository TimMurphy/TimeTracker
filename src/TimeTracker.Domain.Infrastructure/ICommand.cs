using System;

namespace TimeTracker.Domain.Infrastructure
{
    public interface ICommand
    {
        Guid AggregateId { get; }
    }
}