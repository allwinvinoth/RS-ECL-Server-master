using LIS.DataContracts.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.DataContracts.Repositories
{
    public interface IContainerTypeRepository
    {
        Task<ContainerTypeEntity> CreateContainerTypeAsync(ContainerTypeEntity containerTypeEntity, CancellationToken token);

        Task<ContainerTypeEntity> GetContainerTypeByIdAsync(int containerTypeId, CancellationToken token);

        Task<IEnumerable<ContainerTypeEntity>> GetContainerTypesAsync(CancellationToken token);

        Task DeleteContainerTypeByIdAsync(int containerTypeId, CancellationToken token);
    }
}
