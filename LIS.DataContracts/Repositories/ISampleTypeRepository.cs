using LIS.DataContracts.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.DataContracts.Repositories
{
    public interface ISampleTypeRepository
    {
        Task<SampleTypeEntity> CreateSampleTypeAsync(SampleTypeEntity sampleTypeEntity, CancellationToken token);

        Task<SampleTypeEntity> GetSampleTypeEntityByIdAsync(int sampleTypeId, CancellationToken token);

        Task<IEnumerable<SampleTypeEntity>> GetSampleTypeEntitiesAsync(CancellationToken token);

        Task DeleteSampleTypeByIdAsync(int sampleTypeId, CancellationToken token);
    }
}
