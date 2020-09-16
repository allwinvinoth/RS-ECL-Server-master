using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;

namespace LIS.DataContracts.Repositories
{
    public interface IEquipmentRepository
    {
        Task<EquipmentEntity> GetEquipmentById(int id, CancellationToken token);

        Task<EquipmentEntity> CreateEquipmentAsync(EquipmentEntity equipmentEntity, CancellationToken token);

        Task<IEnumerable<EquipmentEntity>> GetEquipmentsByBranchIdAsync(int branchId, CancellationToken token);

        Task<IEnumerable<EquipmentEntity>> GetAll(CancellationToken token);

        Task<EquipmentEntity> UpdateEquipmentAsync(EquipmentEntity equipmentEntity, CancellationToken token);

        Task DeleteEquipmentByIdAsync(int equipmentId, CancellationToken token);
    }
}