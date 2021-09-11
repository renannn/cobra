using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IWriteRepository<TId, T>
        where T : class, IBaseEntity, IHasId<TId>
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(TId id);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        Task ApplySpecificationAsync(ISpecification<T> spec);
    }
}