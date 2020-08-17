using LIS.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.DataContracts.Repositories
{
    public interface IHomeCollectionRepository
    {
        Task<HomeCollectionEntity> CreateHomeCollectionAsync(HomeCollectionEntity homeCollectionEntity, CancellationToken token);

        Task<HomeCollectionEntity> UpdateHomeCollectionByIdAsync(HomeCollectionEntity homeCollectionEntity, CancellationToken token);

        Task DeleteHomeCollectionByIdAsync(int homeCollectionId, CancellationToken token);

        Task<IEnumerable<HomeCollectionEntity>> GetAllHomeCollectionsAsync(CancellationToken token);

        Task<HomeCollectionEntity> GetHomeCollectionByIdAsync(int homeCollectionId, CancellationToken token);
    }
}
