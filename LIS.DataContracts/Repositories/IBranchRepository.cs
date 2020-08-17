using LIS.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.DataContracts.Repositories
{
    public interface IBranchRepository
    {
        Task<BranchEntity> CreateBranchAsync(BranchEntity branchEntity, CancellationToken token);
        
        Task<IEnumerable<BranchEntity>> GetBranchesByOrganisationIdAsync(int organisationId, CancellationToken token);
        
        Task<BranchEntity> UpdateBranchAsync(BranchEntity branchEntity, CancellationToken token);

        Task<BranchEntity> DeleteBranchByIdAsync(int branchId, CancellationToken token);

    }
}
