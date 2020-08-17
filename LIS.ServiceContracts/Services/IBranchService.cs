using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IBranchService
    {
        Task<BranchServiceObject> CreateBranchAsync(BranchServiceObject branchServiceObject, CancellationToken token);
        
        Task<IEnumerable<BranchServiceObject>> GetBranchesByOrganisationIdAsync(int organisationId, CancellationToken token);
        
        Task<BranchServiceObject> UpdateBranchAsync( BranchServiceObject branchServiceObject, CancellationToken token);

        Task<BranchServiceObject> DeleteBranchByIdAsync(int branchId, CancellationToken token);
    }
}
