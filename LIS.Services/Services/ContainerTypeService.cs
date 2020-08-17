using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Services.Services
{
    public class ContainerTypeService : IContainerTypeService
    {
        private readonly IMapper _mapper;
        private readonly IContainerTypeRepository _containerTypeRepository;

        public ContainerTypeService(IContainerTypeRepository containerTypeRepository, IMapper mapper)
        {
            _containerTypeRepository = containerTypeRepository;
            _mapper = mapper;
        }

        public async Task<ContainerTypeServiceObject> CreateContainerTypeAsync(ContainerTypeServiceObject containerType, CancellationToken token)
        {
            var containerTypeEntity = _mapper.Map<ContainerTypeEntity>(containerType);
            var createdEntity = await _containerTypeRepository.CreateContainerTypeAsync(containerTypeEntity, token);
            return _mapper.Map<ContainerTypeServiceObject>(createdEntity);
        }

        public async Task DeleteContainerTypeByIdAsync(int containerTypeId, CancellationToken token)
        {
            await _containerTypeRepository.DeleteContainerTypeByIdAsync(containerTypeId, token);
        }

        public async Task<IEnumerable<ContainerTypeServiceObject>> GetContainerTypesAsync(CancellationToken token)
        {
            var serviceResult = await _containerTypeRepository.GetContainerTypesAsync(token);
            return _mapper.Map<IEnumerable<ContainerTypeServiceObject>>(serviceResult);
        }
    }
}
