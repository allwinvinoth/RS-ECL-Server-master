using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.ServiceContracts.Services
{
    public interface IModulesService
    {
        Task<ModuleServiceObject> CreateModuleAsync(ModuleServiceObject moduleServiceObject, CancellationToken token);

        Task<IEnumerable<ModuleServiceObject>> GetAllModulesByOrganisationId(int organisationId, CancellationToken token);

        Task<ModulePageMappingServiceObject> AddPageToModuleAsync(ModulePageMappingServiceObject modulePageMappingServiceObject, CancellationToken token);

        Task<IEnumerable<PageServiceObject>> GetAllPagesByModuleIdAsync(int moduleId, CancellationToken token);

        Task<ModuleServiceObject> UpdateModuleAsync(ModuleServiceObject moduleServiceObject, CancellationToken token);
    }
}