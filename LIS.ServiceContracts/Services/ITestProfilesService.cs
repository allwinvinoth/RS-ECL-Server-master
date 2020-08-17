using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.ServiceContracts.Services
{
    public interface ITestProfilesService
    {
        Task<TestProfileServiceObject> CreateTestProfileAsync(TestProfileServiceObject testProfileEntity, CancellationToken token);

        Task<TestProfileServiceObject> GetTestProfileByIdAsync(long testProfileId, CancellationToken token);

        Task<IEnumerable<TestProfileServiceObject>> GetAllTestProfileAsync(CancellationToken token);

        Task<TestProfileServiceObject> UpdateTestProfileAsync(TestProfileServiceObject testProfileEntity, CancellationToken token);

        Task DeleteTestProfileByIdAsync(long testProfileId, CancellationToken token);
    }
}