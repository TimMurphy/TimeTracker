using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTracker.Domain.Infrastructure.Events;

namespace TimeTracker.Domain.Infrastructure.Support
{
    public static class Helper
    {
        public static Task<IEnumerable<IEvent>> Events(params IEvent[] events)
        {
            return Task.FromResult(events.AsEnumerable());
        }
    }
}
