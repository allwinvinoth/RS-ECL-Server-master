using LIS.ServiceContracts.ServiceObjects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface ISampleService
    {
        Task<SampleServiceObject> CreateSampleAsync(SampleServiceObject sampleobject, CancellationToken token);

        Task<SampleServiceObject> GetSampleByIdAsync(int sampleId, CancellationToken token);

        Task<IEnumerable<SampleServiceObject>> GetSamplesAsync(CancellationToken token);

        Task<SampleServiceObject> UpdateSampleAsync(SampleServiceObject sampleObject, CancellationToken token);

        Task DeleteSampleByIdAsync(int sampleId, CancellationToken token);
    }
}
