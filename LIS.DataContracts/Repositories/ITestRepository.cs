using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;

namespace LIS.DataContracts.Repositories
{
    public interface ITestRepository
    {
        Task<TestEntity> CreateTestAsync(TestEntity testEntity, CancellationToken token);

        Task<TestEntity> GetTestByIdAsync(long testId, CancellationToken token);

        Task<IEnumerable<TestEntity>> GetTestsByDepartmentIdAsync(int departmentId, CancellationToken token);

        Task<TestEntity> UpdateTestAsync(TestEntity testEntity, CancellationToken token);
        
        Task DeleteTestByIdAsync(long testId, CancellationToken token);

        Task<IEnumerable<TestEntity>> GetTestsByNameAsync(string testName, CancellationToken token);
    }
}