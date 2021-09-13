using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cobra.SharedKernel.Interfaces
{
    public interface INoKeyRepository<T> where T : class
    {
        Task DeleteAsync(T entity);
        Task<T> AddAsync(T entity);
        Task DeleteSpecificationAsync(ISpecification<T> spec);
        IQueryable<T> ApplySpecification(ISpecification<T> spec);
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate);
    }
}
