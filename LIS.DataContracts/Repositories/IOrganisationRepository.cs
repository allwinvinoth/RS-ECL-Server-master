using LIS.DataContracts.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.DataContracts.Repositories
{
    public interface IOrganisationRepository
    {
        Task<OrganisationEntity> AddOrganisationAsync(OrganisationEntity organisationEntity, CancellationToken token);
        
        Task<IEnumerable<OrganisationEntity>> GetOrganisationsAsync(CancellationToken token);

        Task<OrganisationEntity> GetOrganisationByIdAsync(int organisationId, CancellationToken token);
        
        Task<OrganisationEntity> UpdateOrganisationByIdAsync(OrganisationEntity organisationEntity,CancellationToken token);

        Task<OrganisationEntity> DeleteOrganisationByIdAsync(int organisationId, CancellationToken token);

    }
}
