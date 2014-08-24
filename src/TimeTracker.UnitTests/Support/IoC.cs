using BoDi;
using TechTalk.SpecFlow;
using TimeTracker.Domain.Aggregates.Customer.Views;
using TimeTracker.Domain.Infrastructure.Commands;
using TimeTracker.Domain.Infrastructure.Events;
using TimeTracker.UnitTests.Support.Repositories;

namespace TimeTracker.UnitTests.Support
{
    [Binding]
    public class IoC
    {
        private readonly IObjectContainer Container;

        public IoC(IObjectContainer container)
        {
            Container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Container.RegisterTypeAs<CommandBus, ICommandBus>();
            Container.RegisterTypeAs<EventQueue, IEventQueue>();
            Container.RegisterTypeAs<EventStore, IEventStore>();
            Container.RegisterTypeAs<MemoryCustomerViewRepository, ICustomerViewRepository>();
        }
    }
}
