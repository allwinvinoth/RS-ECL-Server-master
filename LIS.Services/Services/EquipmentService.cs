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
    public sealed class EquipmentService : IEquipmentService
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }
        public async Task<EquipmentServiceObject> CreateEquipmentAsync(EquipmentServiceObject equipmentServiceObject, CancellationToken token)
        {
            var equipmentEntity = _mapper.Map<EquipmentEntity>(equipmentServiceObject);
            var createdEntity = await _equipmentRepository.CreateEquipmentAsync(equipmentEntity, token);
            return _mapper.Map<EquipmentServiceObject>(createdEntity);
        }
        public async Task<IEnumerable<EquipmentServiceObject>> GetEquipmentsByBranchIdAsync(int branchId, CancellationToken token)
        {
            var serviceResult = await _equipmentRepository.GetEquipmentsByBranchIdAsync(branchId, token);
            return _mapper.Map<IEnumerable<EquipmentServiceObject>>(serviceResult);
        }

        public async Task<IEnumerable<EquipmentServiceObject>> GetAll(CancellationToken token)
        {
            var serviceResult = await _equipmentRepository.GetAll(token);
            return _mapper.Map<IEnumerable<EquipmentServiceObject>>(serviceResult);
        }
        public async Task<EquipmentServiceObject> UpdateEquipmentAsync(EquipmentServiceObject equipmentServiceObject, CancellationToken token)
        {
            var equipmentEntity = _mapper.Map<EquipmentEntity>(equipmentServiceObject);
            var updatedEntity = await _equipmentRepository.UpdateEquipmentAsync(equipmentEntity, token);
            return _mapper.Map<EquipmentServiceObject>(updatedEntity);
        }
        public async Task DeleteEquipmentByIdAsync(int equipmentId, CancellationToken token)
        {
            await _equipmentRepository.DeleteEquipmentByIdAsync(equipmentId, token);
        }
    }
}
