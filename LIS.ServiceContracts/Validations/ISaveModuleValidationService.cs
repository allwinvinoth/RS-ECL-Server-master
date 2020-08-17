using System.Threading;
using System.Threading.Tasks;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.ServiceContracts.Validations
{
    public interface ISaveModuleValidationService
    {
        Task Validate(ModuleServiceObject saveModuleServiceObject, CancellationToken token);
    }
}