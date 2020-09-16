using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;

namespace LIS.DataContracts.Repositories
{
    public interface IMethodRepository
    {
        Task<MethodEntity> GetMethodById(int id, CancellationToken token);

        Task<MethodEntity> CreateMethodAsync(MethodEntity departmentEntity, CancellationToken token);

        Task<IEnumerable<MethodEntity>> GetMethodsByBranchIdAsync(int branchId, CancellationToken token);

        Task<IEnumerable<MethodEntity>> GetAll(CancellationToken token);

        Task<MethodEntity> UpdateMethodAsync(MethodEntity departmentEntity, CancellationToken token);

        Task DeleteMethodByIdAsync(int departmentId, CancellationToken token);
    }
}