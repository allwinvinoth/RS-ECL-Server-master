using LIS.ServiceContracts.ServiceObjects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IContainerTypeService
    {
        Task<ContainerTypeServiceObject> CreateContainerTypeAsync(ContainerTypeServiceObject containerType, CancellationToken token);

        Task<IEnumerable<ContainerTypeServiceObject>> GetContainerTypesAsync(CancellationToken token);

        Task DeleteContainerTypeByIdAsync(int containerTypeId, CancellationToken token);
    }
}
