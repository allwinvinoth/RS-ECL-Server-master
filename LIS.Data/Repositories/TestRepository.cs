using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using LIS.Common.Extensions;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LIS.Data.Repositories
{
    public sealed class TestRepository : ITestRepository
    {
        private readonly LISDbContext _dbContext;

        public TestRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TestEntity> CreateTestAsync(TestEntity testEntity, CancellationToken token)
        {
            await _dbContext.Tests.AddAsync(testEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return testEntity;
        }

        public async Task<TestEntity> GetTestByIdAsync(long testId, CancellationToken token)
        {
            Expression<Func<TestEntity, bool>> condition = testEntity => testEntity.Id == testId && testEntity.IsActive;
            return await _dbContext.Tests.SingleAsync(condition, cancellationToken: token);
        }

        public async Task<IEnumerable<TestEntity>> GetTestsByDepartmentIdAsync(int departmentId, CancellationToken token)
        {
            return await _dbContext.Tests
                                   .Where(test => test.DepartmentId == departmentId && test.IsActive)
                                   .ToListAsync(token);
        }

        public async Task<TestEntity> UpdateTestAsync(TestEntity testEntity, CancellationToken token)
        {
            _dbContext.Tests.Update(testEntity);
            await _dbContext.SaveChangesAsync(token);
            return testEntity;
        }

        public async Task DeleteTestByIdAsync(long testId, CancellationToken token)
        {
            var testEntity = await _dbContext.Tests.SingleAsync(test => test.Id == testId, token);
            testEntity.IsActive = false;
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<IEnumerable<TestEntity>> GetTestsByNameAsync(string testName, CancellationToken token)
        {
            return await _dbContext.Tests
                                   .Where(test => test.Name.Contains(testName) && test.IsActive).ToListAsync(token);
        }
    }
}