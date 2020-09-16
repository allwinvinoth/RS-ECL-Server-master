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
    public sealed class IndividualTestMasterRepository : IIndividualTestMasterRepository
    {
        private readonly LISDbContext _dbContext;

        public IndividualTestMasterRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IndividualTestEntity> GetIndividualTestMasterById(int id, CancellationToken token)
        {
            return await _dbContext.IndividualTestMasters
                                   .SingleAsync(IndividualTestMaster => IndividualTestMaster.Id == id && IndividualTestMaster.IsActive, token);
        }

        public async Task<IndividualTestEntity> CreateIndividualTestMasterAsync(IndividualTestEntity IndividualTestEntity, CancellationToken token)
        {
            IndividualTestEntity.IsActive = true;
            await _dbContext.IndividualTestMasters.AddAsync(IndividualTestEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return IndividualTestEntity;
        }

        public async Task<IEnumerable<IndividualTestEntity>> GetIndividualTestMastersByBranchIdAsync(int branchId, CancellationToken token)
        {
            return await _dbContext.IndividualTestMasters.Where(IndividualTestMaster => IndividualTestMaster.IsActive).ToListAsync(token);
        }

        public async Task<IEnumerable<IndividualTestEntity>> GetAll(CancellationToken token)
        {
            try
            {
                return await _dbContext.IndividualTestMasters.Where(IndividualTestMaster => IndividualTestMaster.IsActive).Include(x => x.Method).Include(x => x.Lookup).ToListAsync(token);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IndividualTestEntity> UpdateIndividualTestMasterAsync(IndividualTestEntity IndividualTestEntity, CancellationToken token)
        {
            _dbContext.IndividualTestMasters.Update(IndividualTestEntity);
            await _dbContext.SaveChangesAsync(token);
            return IndividualTestEntity;
        }

        public async Task DeleteIndividualTestMasterByIdAsync(int IndividualTestMasterId, CancellationToken token)
        {
            var IndividualTestEntity =await _dbContext.IndividualTestMasters.SingleAsync(IndividualTestMaster => IndividualTestMaster.Id == IndividualTestMasterId && IndividualTestMaster.IsActive,token);
            IndividualTestEntity.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }
    }
}