using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;

namespace LIS.DataContracts.Repositories
{
    public interface IPageRepository
    {
        Task<PageEntity> CreatePageAsync(PageEntity pageEntity, CancellationToken token);

        Task<IEnumerable<PageEntity>> GetAllPagesForOrganisationAsync(int organisationId, CancellationToken token);

        Task<PageEntity> UpdatePageAsync(PageEntity pageEntity, CancellationToken token);
    }
}