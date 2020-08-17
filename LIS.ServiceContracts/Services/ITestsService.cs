using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.ServiceContracts.Services
{
    public interface ITestsService
    {
        Task<TestServiceObject> CreateTestAsync(TestServiceObject testServiceObject, CancellationToken token);

        Task<TestServiceObject> GetTestByIdAsync(long testId, CancellationToken token);

        Task<IEnumerable<TestServiceObject>> GetTestsByDepartmentIdAsync(int departmentId, CancellationToken token);
        
        Task<TestServiceObject> UpdateTestAsync(TestServiceObject testServiceObject, CancellationToken token);

        Task DeleteTestByIdAsync(long testId, CancellationToken token);

        Task<IEnumerable<TestServiceObject>> GetTestsByNameAsync(string testName, CancellationToken token);
    }
}