using CodereTecnicalTest.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Infrastructure.Context
{
    public class CodereTecnicalTestUnitOfWork(CodereTecnicalTestDBContext dBContext) : IUnitOfWork
    {
        private readonly CodereTecnicalTestDBContext _dbContext = dBContext;
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
