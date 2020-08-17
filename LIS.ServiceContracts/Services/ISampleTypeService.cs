using LIS.ServiceContracts.ServiceObjects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface ISampleTypeService
    {
        Task<SampleTypeServiceObject> CreateSampleTypeAsync(SampleTypeServiceObject sampleTypeServiceObject, CancellationToken token);

        Task<SampleTypeServiceObject> GetSampleTypeByIdAsync(int sampleTypeId, CancellationToken token);

        Task<IEnumerable<SampleTypeServiceObject>> GetSampleTypesAsync(CancellationToken token);

        Task DeleteSampleTypeByIdAsync(int sampleTypeId, CancellationToken token);
    }
}
