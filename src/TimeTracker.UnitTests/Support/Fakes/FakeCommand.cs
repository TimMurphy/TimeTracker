using System;
using TimeTracker.Domain.Infrastructure.Commands;

namespace TimeTracker.UnitTests.Support.Fakes
{
    public class FakeCommand : ICommand
    {
        public FakeCommand()
        {
            AggregateId = Guid.NewGuid();
        }

        public Guid AggregateId { get; private set; }
    }
}