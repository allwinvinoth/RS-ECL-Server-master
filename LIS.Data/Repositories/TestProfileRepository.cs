using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LIS.Data.Repositories
{
    public sealed class TestProfileRepository : ITestProfileRepository
    {
        private readonly LISDbContext _dbContext;
        public TestProfileRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TestProfileEntity> CreateTestProfileAsync(TestProfileEntity testProfileEntity, CancellationToken token)
        {
            await _dbContext.TestProfiles.AddAsync(testProfileEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return testProfileEntity;
        }

        public async Task<TestProfileEntity> UpdateTestProfileAsync(TestProfileEntity testProfileEntity, CancellationToken token)
        {
            _dbContext.TestProfiles.Update(testProfileEntity);
            await _dbContext.SaveChangesAsync(token);
            return testProfileEntity;
        }

        public async Task DeleteTestProfileByIdAsync(long testProfileId, CancellationToken token)
        {
            var testProfileEntity = await _dbContext.TestProfiles.SingleAsync(testProfile => testProfile.Id == testProfileId, token);
            testProfileEntity.IsActive = false;
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<IEnumerable<TestProfileEntity>> GetAllTestProfileAsync(CancellationToken token)
        {
            return await _dbContext.TestProfiles.Where(testProfileEntity => testProfileEntity.IsActive).ToListAsync(token);
        }

        public async Task<TestProfileEntity> GetTestProfileByIdAsync(long testProfileId, CancellationToken token)
        {
            Expression<Func<TestProfileEntity, bool>> condition = testProfileEntity => testProfileEntity.Id == testProfileId && testProfileEntity.IsActive;
            return await _dbContext.TestProfiles.SingleAsync(condition, cancellationToken: token);
        }
    }
}