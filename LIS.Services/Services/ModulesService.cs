using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using LIS.ServiceContracts.Validations;

namespace LIS.Services.Services
{
    public sealed class ModulesService : IModulesService
    {
        private readonly IModuleRepository _moduleRepository;

        private readonly IMapper _mapper;

        private readonly ISaveModuleValidationService _saveModuleValidationService;

        public ModulesService(IModuleRepository moduleRepository, IMapper mapper, ISaveModuleValidationService saveModuleValidationService)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
            _saveModuleValidationService = saveModuleValidationService;
        }

        public async Task<ModuleServiceObject> CreateModuleAsync(ModuleServiceObject moduleServiceObject, CancellationToken token)
        {
            await _saveModuleValidationService.Validate(moduleServiceObject, token);
            var moduleEntity = _mapper.Map<ModuleEntity>(moduleServiceObject);
            var createdEntity = await _moduleRepository.CreateModuleAsync(moduleEntity, token);
            return _mapper.Map<ModuleServiceObject>(createdEntity);
        }

        public async Task<IEnumerable<ModuleServiceObject>> GetAllModulesByOrganisationId(int organisationId, CancellationToken token)
        {
            var serviceResult = await _moduleRepository.GetAllModulesByOrganisationId(organisationId, token);
            return _mapper.Map<IEnumerable<ModuleServiceObject>>(serviceResult);
        }

        public async Task<ModuleServiceObject> UpdateModuleAsync(ModuleServiceObject moduleServiceObject, CancellationToken token)
        {
            await _saveModuleValidationService.Validate(moduleServiceObject, token);
            var moduleEntity = _mapper.Map<ModuleEntity>(moduleServiceObject);
            var updatedEntity = await _moduleRepository.UpdateModuleAsync(moduleEntity, token);
            return _mapper.Map<ModuleServiceObject>(updatedEntity);
        }

        public async Task<ModulePageMappingServiceObject> AddPageToModuleAsync(ModulePageMappingServiceObject modulePageMappingServiceObject, CancellationToken token)
        {
            var modulePageMappingEntity = _mapper.Map<ModulePageMappingEntity>(modulePageMappingServiceObject);
            var createdEntity = await _moduleRepository.AddPageToModuleAsync(modulePageMappingEntity, token);
            return _mapper.Map<ModulePageMappingServiceObject>(createdEntity);
        }

        public async Task<IEnumerable<PageServiceObject>> GetAllPagesByModuleIdAsync(int moduleId, CancellationToken token)
        {
            var serviceResult = await _moduleRepository.GetAllPagesByModuleIdAsync(moduleId, token);
            return _mapper.Map<IEnumerable<PageServiceObject>>(serviceResult);
        }
    }
}