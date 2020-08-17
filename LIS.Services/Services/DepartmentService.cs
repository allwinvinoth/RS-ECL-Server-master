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
    public sealed class DepartmentService:IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<DepartmentServiceObject> CreateDepartmentAsync(DepartmentServiceObject departmentServiceObject, CancellationToken token)
        {
            var departmentEntity = _mapper.Map<DepartmentEntity>(departmentServiceObject);
            var createdEntity = await _departmentRepository.CreateDepartmentAsync(departmentEntity, token);
            return _mapper.Map<DepartmentServiceObject>(createdEntity);
        }
        public async Task<IEnumerable<DepartmentServiceObject>> GetDepartmentsByBranchIdAsync(int branchId, CancellationToken token)
        {
            var serviceResult = await _departmentRepository.GetDepartmentsByBranchIdAsync(branchId, token);
            return _mapper.Map<IEnumerable<DepartmentServiceObject>>(serviceResult);
        }
        public async Task<DepartmentServiceObject> UpdateDepartmentAsync(DepartmentServiceObject departmentServiceObject, CancellationToken token)
        {
            var departmentEntity = _mapper.Map<DepartmentEntity>(departmentServiceObject);
            var updatedEntity = await _departmentRepository.UpdateDepartmentAsync(departmentEntity, token);
            return _mapper.Map<DepartmentServiceObject>(updatedEntity);
        }
        public async Task DeleteDepartmentByIdAsync(int departmentId, CancellationToken token)
        {
            await _departmentRepository.DeleteDepartmentByIdAsync(departmentId, token);
        }
    }
}
