using System;

namespace TimeTracker.Domain.Infrastructure
{
    public static class Mapping
    {
        public static TTo MapTo<TTo>(this object obj)
            where TTo : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
