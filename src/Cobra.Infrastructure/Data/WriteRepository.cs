using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Cobra.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Data
{
    public class WriteRepository<TId, T> : IWriteRepository<TId, T>
        where T : class, IBaseEntity, IHasId<TId>
    {
        private readonly AppDbContext _dbContext;

        public WriteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TId id)
        {
            var entity = await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var itens = _dbContext.Set<T>().Where(predicate).ToList();
            itens.ForEach(x => _dbContext.Set<T>().Remove(x));
            await _dbContext.SaveChangesAsync();
        }

        public async Task ApplySpecificationAsync(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator();
            await evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec).ForEachAsync(x => _dbContext.Set<T>().Remove(x));
        }
    }
}
