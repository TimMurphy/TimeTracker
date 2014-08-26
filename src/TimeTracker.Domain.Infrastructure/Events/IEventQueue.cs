using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public interface IEventQueue
    {
        Task AddAsync(IEnumerable<IEvent> events);
        Task ProcessAsync();
    }
}