using LIS.ServiceContracts.ServiceObjects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IOrganisationService
    {
        Task<OrganisationServiceObject> AddOrganisationAsync(OrganisationServiceObject organisationServiceObject, CancellationToken token);
        
        Task<IEnumerable<OrganisationServiceObject>> GetOrganisationsAsync(CancellationToken token);

        Task<OrganisationServiceObject> GetOrganisationByIdAsync(int organisationId, CancellationToken token);
        
        Task<OrganisationServiceObject> UpdateOrganisationByIdAsync(OrganisationServiceObject organisationServiceObject, CancellationToken token);

        Task<OrganisationServiceObject> DeleteOrganisationByIdAsync(int organisationId,CancellationToken token);

    }
}
