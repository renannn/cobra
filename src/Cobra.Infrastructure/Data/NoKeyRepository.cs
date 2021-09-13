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
    public class NoKeyRepository<T> : INoKeyRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public NoKeyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteSpecificationAsync(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator();
            var itens = evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec).ToList();

            await Task.Run(() =>
            {
                itens.ForEach(async x => await DeleteAsync(x));
            });
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator();
            var entities = evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
            return entities;
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsExpandable().Where(predicate).ToListAsync();
        }
    }
}
