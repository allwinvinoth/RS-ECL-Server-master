using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IMethodService
    {
        Task<MethodServiceObject> CreateMethodAsync(MethodServiceObject MethodServiceObject, CancellationToken token);

        Task<IEnumerable<MethodServiceObject>> GetMethodsByBranchIdAsync(int branchId, CancellationToken token);

        Task<IEnumerable<MethodServiceObject>> GetAll(CancellationToken token);

        Task<MethodServiceObject> UpdateMethodAsync(MethodServiceObject MethodServiceObject, CancellationToken token);

        Task DeleteMethodByIdAsync(int MethodId, CancellationToken token);
    }
}
