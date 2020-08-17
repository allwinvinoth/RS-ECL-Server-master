using LIS.DataContracts.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.DataContracts.Repositories
{
    public interface ISampleRepository
    {
        Task<SampleEntity> CreateSampleAsync(SampleEntity sampleEntity, CancellationToken token);

        Task<SampleEntity> GetSampleByIdAsync(int sampleId, CancellationToken token);

        Task<IEnumerable<SampleEntity>> GetSamplesAsync(CancellationToken token);

        Task<SampleEntity> UpdateSampleAsync(SampleEntity sampleEntity, CancellationToken token);

        Task DeleteSampleByIdAsync(int sampleId, CancellationToken token);
    }
}
