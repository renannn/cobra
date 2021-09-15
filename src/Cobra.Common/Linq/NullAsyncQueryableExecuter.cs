using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cobra.Common.Linq
{
    public class NullAsyncQueryableExecuter : IAsyncQueryableExecuter
    {
        public static NullAsyncQueryableExecuter Instance
        {
            get;
        }

        static NullAsyncQueryableExecuter()
        {
            NullAsyncQueryableExecuter.Instance = new NullAsyncQueryableExecuter();
        }

        public NullAsyncQueryableExecuter()
        {
        }

        public Task<bool> AnyAsync<T>(IQueryable<T> queryable)
        {
            return Task.FromResult<bool>(queryable.Any<T>());
        }

        public Task<int> CountAsync<T>(IQueryable<T> queryable)
        {
            return Task.FromResult<int>(queryable.Count<T>());
        }

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable)
        {
            return Task.FromResult<T>(queryable.FirstOrDefault<T>());
        }

        public Task<List<T>> ToListAsync<T>(IQueryable<T> queryable)
        {
            return Task.FromResult<List<T>>(queryable.ToList<T>());
        }
    }
}