using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.ServiceContracts.Services
{
    public interface IPagesService
    {
        Task<PageServiceObject> CreatePageAsync(PageServiceObject pageServiceObject, CancellationToken token);

        Task<IEnumerable<PageServiceObject>> GetAllPagesForOrganisationAsync(int organisationId, CancellationToken token);

        Task<PageServiceObject> UpdatePageAsync(PageServiceObject pageServiceObject, CancellationToken token);
    }
}