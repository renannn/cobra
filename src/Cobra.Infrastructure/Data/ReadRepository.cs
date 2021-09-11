using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Cobra.SharedKernel.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Data
{
    public class ReadRepository<TId, T> : IReadRepository<TId, T>
        where T : class, IBaseEntity, IHasId<TId>
    {

        private readonly AppDbContext _dbContext;

        public ReadRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator();
            var entities = evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
            return entities;
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> orderBy)
        {
            return await _dbContext.Set<T>().AsExpandable().Where(predicate).OrderBy(orderBy).ToListAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsExpandable().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, int offset, int fetch)
        {
            return await _dbContext.Set<T>().AsExpandable().Where(predicate).Skip(offset).Take(fetch).ToListAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> orderBy, int offset, int fetch)
        {
            return await _dbContext.Set<T>().AsExpandable().Where(predicate).OrderBy(orderBy).Skip(offset).Take(fetch).ToListAsync();
        }

        public int QueryCount(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().AsExpandable().Count(predicate);
        }

    }
}