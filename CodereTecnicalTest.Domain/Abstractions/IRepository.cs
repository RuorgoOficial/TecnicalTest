using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Abstractions
{
    public interface IRepository<T> where T : Base
    {
        Task AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entities);
        Task RemoveAsync(T entity);
        Task RemoveAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        ValueTask<T?> FindByIdAsync(int id, CancellationToken cancellationToken);
        ValueTask<T?> FindByIdAsync(int id, CancellationToken cancellationToken, bool asNoTracking = false, Includes.Includes? includes = null);
        Task<T[]> FindAsync(ISpecification<T> spec, CancellationToken cancellationToken, bool asNoTracking = false, Includes.Includes? includes = null);
        Task<T[]> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false, Includes.Includes? includes = null);
    }
}
