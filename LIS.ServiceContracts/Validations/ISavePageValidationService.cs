using System.Threading;
using System.Threading.Tasks;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.ServiceContracts.Validations
{
    public interface ISavePageValidationService
    {
        Task Validate(PageServiceObject savePageServiceObject, CancellationToken token);
    }
}