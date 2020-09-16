using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace LIS.Data.Repositories
{
    public sealed class LookupRepository : ILookupRepository
    {
        private readonly LISDbContext _dbContext;

        public LookupRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<LookupEntity>> GetAll(string param, CancellationToken token)
        {
            try
            {
                return await _dbContext.Lookup.Where(Lookup => Lookup.Param == param && Lookup.IsActive).ToListAsync(token);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}