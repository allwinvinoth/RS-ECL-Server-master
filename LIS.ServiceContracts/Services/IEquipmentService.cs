using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IEquipmentService
    {
        Task<EquipmentServiceObject> CreateEquipmentAsync(EquipmentServiceObject departmentServiceObject, CancellationToken token);

        Task<IEnumerable<EquipmentServiceObject>> GetEquipmentsByBranchIdAsync(int branchId, CancellationToken token);

        Task<IEnumerable<EquipmentServiceObject>> GetAll(CancellationToken token);

        Task<EquipmentServiceObject> UpdateEquipmentAsync(EquipmentServiceObject departmentServiceObject, CancellationToken token);

        Task DeleteEquipmentByIdAsync(int departmentId, CancellationToken token);
    }
}
