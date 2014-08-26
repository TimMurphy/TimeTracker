using System.Collections.Generic;

namespace TimeTracker.UnitTests.Support.Fakes.Repositories
{
    public class FakeRepository<TEntity> where TEntity : class
    {
        protected readonly List<TEntity> Items = new List<TEntity>();
    }
}