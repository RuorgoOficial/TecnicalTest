using CodereTecnicalTest.Domain.Abstractions;
using CodereTecnicalTest.Domain.Entities;
using CodereTecnicalTest.Domain.Includes;
using CodereTecnicalTest.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Infrastructure.Access
{
    public class CodereTecnicalTestRepository<T>(CodereTecnicalTestDBContext context) : IRepository<T>
        where T : Base
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<T[]> FindAsync(ISpecification<T> spec, CancellationToken cancellationToken, bool asNoTracking = false, Includes? includes = null)
        {
            var query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
            query = query.Where(spec.Criteria);

            if (spec.OrderBy is not null)
                query = query.OrderBy(spec.OrderBy);

            if (includes is not null)
                query = ApplyIncludes(query, includes);

            return await query.ToArrayAsync(cancellationToken);
        }

        public ValueTask<T?> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async ValueTask<T?> FindByIdAsync(int id, CancellationToken cancellationToken, bool asNoTracking = false, Includes? includes = null)
        {
            var query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
            if (includes is not null)
                query = ApplyIncludes(query, includes);

            return await query.Where(q => q.id == id).FirstOrDefaultAsync();
        }

        public Task<T[]> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false, Includes? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes is not null)
                query = ApplyIncludes(query, includes);

            return query.ToArrayAsync(cancellationToken);
        }

        public Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;

        }

        public Task RemoveAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        private static IQueryable<T> ApplyIncludes(IQueryable<T> query, Includes includes)
        {
            foreach (var include in includes.IncludeList)
            {
                query = query.Include(include);
            }

            if(includes.IncludeChild is not null)
                    query = ApplyIncludes(query, includes.IncludeChild);

            return query;
        }
    }
}
