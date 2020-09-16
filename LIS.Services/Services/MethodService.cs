using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Services.Services
{
    public sealed class MethodService:IMethodService
    {
        private readonly IMapper _mapper;
        private readonly IMethodRepository _methodRepository;
        public MethodService(IMethodRepository methodRepository, IMapper mapper)
        {
            _methodRepository = methodRepository;
            _mapper = mapper;
        }
        public async Task<MethodServiceObject> CreateMethodAsync(MethodServiceObject methodServiceObject, CancellationToken token)
        {
            var methodEntity = _mapper.Map<MethodEntity>(methodServiceObject);
            var createdEntity = await _methodRepository.CreateMethodAsync(methodEntity, token);
            return _mapper.Map<MethodServiceObject>(createdEntity);
        }
        public async Task<IEnumerable<MethodServiceObject>> GetMethodsByBranchIdAsync(int branchId, CancellationToken token)
        {
            var serviceResult = await _methodRepository.GetMethodsByBranchIdAsync(branchId, token);
            return _mapper.Map<IEnumerable<MethodServiceObject>>(serviceResult);
        }

        public async Task<IEnumerable<MethodServiceObject>> GetAll(CancellationToken token)
        {
            var serviceResult = await _methodRepository.GetAll(token);
            return _mapper.Map<IEnumerable<MethodServiceObject>>(serviceResult);
        }
        public async Task<MethodServiceObject> UpdateMethodAsync(MethodServiceObject methodServiceObject, CancellationToken token)
        {
            var methodEntity = _mapper.Map<MethodEntity>(methodServiceObject);
            var updatedEntity = await _methodRepository.UpdateMethodAsync(methodEntity, token);
            return _mapper.Map<MethodServiceObject>(updatedEntity);
        }
        public async Task DeleteMethodByIdAsync(int methodId, CancellationToken token)
        {
            await _methodRepository.DeleteMethodByIdAsync(methodId, token);
        }
    }
}
