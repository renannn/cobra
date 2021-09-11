using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IReadRepository<TId, T>
        where T : class, IBaseEntity, IHasId<TId>
    {
        Task<T> GetByIdAsync(TId id);
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> orderBy);
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, int offset, int fetch);
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> orderBy, int offset, int fetch);
        int QueryCount(Expression<Func<T, bool>> predicate);
        IQueryable<T> ApplySpecification(ISpecification<T> spec);
    }
}
