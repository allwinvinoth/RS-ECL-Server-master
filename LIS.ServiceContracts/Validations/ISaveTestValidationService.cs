using System.Threading;
using System.Threading.Tasks;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.ServiceContracts.Validations
{
    public interface ISaveTestValidationService
    {
        Task Validate(TestServiceObject saveTestServiceObject, CancellationToken token);
    }
}