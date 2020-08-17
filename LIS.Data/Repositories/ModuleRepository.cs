using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;


namespace LIS.Data.Repositories
{
    public sealed class ModuleRepository : IModuleRepository
    {
        private readonly LISDbContext _dbContext;
        public ModuleRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ModuleEntity> CreateModuleAsync(ModuleEntity moduleEntity, CancellationToken token)
        {
            await _dbContext.Modules.AddAsync(moduleEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return moduleEntity;
        }

        public async Task<IEnumerable<ModuleEntity>> GetAllModulesByOrganisationId(int organisationId, CancellationToken token)
        {
            return await _dbContext.Modules.Where(module => module.OrganisationId == organisationId && module.IsActive).ToListAsync(token);
        }

        public async Task<ModuleEntity> UpdateModuleAsync(ModuleEntity moduleEntity, CancellationToken token)
        {
            _dbContext.Modules.Update(moduleEntity);
            await _dbContext.SaveChangesAsync(token);
            return moduleEntity;
        }

        public async Task<ModulePageMappingEntity> AddPageToModuleAsync(ModulePageMappingEntity modulePageMappingEntity, CancellationToken token)
        {
            await _dbContext.Modules_Pages_Mapping.AddAsync(modulePageMappingEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return modulePageMappingEntity;
        }

        public async Task<IEnumerable<PageEntity>> GetAllPagesByModuleIdAsync(int moduleId, CancellationToken token)
        {
            var pageEntities = _dbContext.Pages;
            return await _dbContext.Modules_Pages_Mapping.Where(modulePageMapping => modulePageMapping.ModuleId == moduleId)
                                                         .Join(pageEntities,
                                                                modulePageMapping => modulePageMapping.PageId,
                                                                page => page.Id,
                                                                (modulePageMapping, page) => new PageEntity
                                                                {
                                                                    Id = page.Id,
                                                                    Name = page.Name,
                                                                    OrganisationId = page.OrganisationId
                                                                }
                                                                ).ToListAsync(token);
        }
    }
}