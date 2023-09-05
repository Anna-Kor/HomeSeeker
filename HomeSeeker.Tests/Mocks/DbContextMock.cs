using Microsoft.EntityFrameworkCore;

using NSubstitute;

namespace HomeSeeker.Tests.Mocks
{
    public static class DbSetMock
    {
        public static DbSet<T> CreateMockDbSet<T>(IEnumerable<T> data = null)
        where T : class
        {
            var mockSet = Substitute.For<DbSet<T>, IQueryable<T>, IAsyncEnumerable<T>>();

            if (data != null)
            {
                var queryable = data.AsQueryable();

                ((IAsyncEnumerable<T>)mockSet).GetAsyncEnumerator()
                .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));
                ((IQueryable<T>)mockSet).Provider.Returns(new TestDbAsyncQueryProvider<T>(queryable.Provider));
                ((IQueryable<T>)mockSet).Expression.Returns(queryable.Expression);
                ((IQueryable<T>)mockSet).ElementType.Returns(queryable.ElementType);
                ((IQueryable<T>)mockSet).GetEnumerator().Returns(queryable.GetEnumerator());
            }

            return mockSet;
        }
    }
}
