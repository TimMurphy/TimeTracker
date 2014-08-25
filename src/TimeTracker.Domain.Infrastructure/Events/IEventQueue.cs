using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public interface IEventQueue
    {
        Task ProcessAsync();
        Task AddAsync(IEnumerable<IEvent> events);
    }
}