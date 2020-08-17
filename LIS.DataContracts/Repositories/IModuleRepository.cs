using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;

namespace LIS.DataContracts.Repositories
{
    public interface IModuleRepository
    {
        Task<ModuleEntity> CreateModuleAsync(ModuleEntity moduleEntity, CancellationToken token);

        Task<IEnumerable<ModuleEntity>> GetAllModulesByOrganisationId(int organisationId, CancellationToken token);

        Task<ModuleEntity> UpdateModuleAsync(ModuleEntity moduleEntity, CancellationToken token);

        Task<ModulePageMappingEntity> AddPageToModuleAsync(ModulePageMappingEntity modulePageMappingEntity, CancellationToken token);

        Task<IEnumerable<PageEntity>> GetAllPagesByModuleIdAsync(int moduleId, CancellationToken token);
    }
}