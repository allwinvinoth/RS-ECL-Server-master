using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;

namespace LIS.DataContracts.Repositories
{
    public interface IIndividualTestMasterRepository
    {
        Task<IndividualTestEntity> GetIndividualTestMasterById(int id, CancellationToken token);

        Task<IndividualTestEntity> CreateIndividualTestMasterAsync(IndividualTestEntity individualTestEntity, CancellationToken token);

        Task<IEnumerable<IndividualTestEntity>> GetAll(CancellationToken token);

        Task<IndividualTestEntity> UpdateIndividualTestMasterAsync(IndividualTestEntity individualTestEntity, CancellationToken token);

        Task DeleteIndividualTestMasterByIdAsync(int individualTestId, CancellationToken token);
    }
}