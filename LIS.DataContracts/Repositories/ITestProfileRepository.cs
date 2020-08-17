using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;

namespace LIS.DataContracts.Repositories
{
    public interface ITestProfileRepository
    {
        Task<TestProfileEntity> CreateTestProfileAsync(TestProfileEntity testProfileEntity, CancellationToken token);

        Task<TestProfileEntity> GetTestProfileByIdAsync(long testProfileId, CancellationToken token);

        Task<IEnumerable<TestProfileEntity>> GetAllTestProfileAsync(CancellationToken token);

        Task<TestProfileEntity> UpdateTestProfileAsync(TestProfileEntity testProfileEntity, CancellationToken token);

        Task DeleteTestProfileByIdAsync(long testProfileId, CancellationToken token);
    }
}