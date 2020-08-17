using LIS.ServiceContracts.ServiceObjects;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Validations
{
    public interface ISaveSampleValidationService
    {
        Task Validate(SampleServiceObject saveSampleServiceObject, CancellationToken token);
    }
}
