using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Data.Repositories
{
    public sealed class BranchRepository : IBranchRepository
    {
        private readonly LISDbContext _dbContext;

        public BranchRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BranchEntity> CreateBranchAsync(BranchEntity branchEntity, CancellationToken token)
        {
            await _dbContext.Branches.AddAsync(branchEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return branchEntity;
        }
        public async Task<IEnumerable<BranchEntity>> GetBranchesByOrganisationIdAsync(int organisationId, CancellationToken token)
        {
            return await _dbContext.Branches.Where(branch => branch.OrganisationId == organisationId && branch.IsActive).ToListAsync(token);
        }
        public async Task<BranchEntity> UpdateBranchAsync(BranchEntity branchEntity, CancellationToken token)
        {
            _dbContext.Branches.Update(branchEntity);
            await _dbContext.SaveChangesAsync(token);
            return branchEntity;
        }
        public async Task<BranchEntity> DeleteBranchByIdAsync(int branchId, CancellationToken token)
        {
            var branchEntity=_dbContext.Branches.First(branch => branch.Id == branchId && branch.IsActive);
            branchEntity.IsActive=false;
            await _dbContext.SaveChangesAsync();
            return branchEntity;

        }
    }
}