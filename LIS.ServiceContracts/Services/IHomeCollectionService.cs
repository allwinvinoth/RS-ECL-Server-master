using LIS.ServiceContracts.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.Services
{
    public interface IHomeCollectionService
    {
        Task<HomeCollectionServiceObject> CreateHomeCollectionAsync(HomeCollectionServiceObject homeCollectionServiceObject, CancellationToken token);

        Task<HomeCollectionServiceObject> UpdateHomeCollectionByIdAsync(HomeCollectionServiceObject homeCollectionServiceObject, CancellationToken token);

        Task DeleteHomeCollectionByIdAsync(int homeCollectionId, CancellationToken token);

        Task<IEnumerable<HomeCollectionServiceObject>> GetAllHomeCollectionsAsync(CancellationToken token);

        Task<HomeCollectionServiceObject> GetHomeCollectionByIdAsync(int homeCollectionId, CancellationToken token);
    }
}
