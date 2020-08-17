using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Data.Repositories
{
    public sealed class HomeCollectionRepository : IHomeCollectionRepository
    {
        private readonly LISDbContext _dbContext;

        public HomeCollectionRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HomeCollectionEntity> CreateHomeCollectionAsync(HomeCollectionEntity homeCollectionEntity, CancellationToken token)
        {
            await _dbContext.HomeCollections.AddAsync(homeCollectionEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return await _dbContext.HomeCollections
                                    .Include(x => x.Gender)
                                    .SingleAsync(homeCollection => homeCollection.Id == homeCollectionEntity.Id, token);
        }

        public async Task<HomeCollectionEntity> UpdateHomeCollectionByIdAsync(HomeCollectionEntity homeCollectionEntity, CancellationToken token)
        {
            _dbContext.HomeCollections.Update(homeCollectionEntity);
            await _dbContext.SaveChangesAsync(token);
            return await _dbContext.HomeCollections
                                    .Include(x => x.Gender)
                                    .SingleAsync(homeCollection => homeCollection.Id == homeCollectionEntity.Id, token);
        }

        public async Task DeleteHomeCollectionByIdAsync(int homeCollectionId, CancellationToken token)
        {
            var homeCollectionEntity =await _dbContext.HomeCollections.SingleAsync(homeCollection => homeCollection.Id == homeCollectionId, token);
            homeCollectionEntity.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<HomeCollectionEntity>> GetAllHomeCollectionsAsync(CancellationToken token)
        {
            return await _dbContext.HomeCollections
                                    .Include(x => x.Gender)
                                    .Where(homeCollection => homeCollection.IsActive).ToListAsync(token);
        }

        public async Task<HomeCollectionEntity> GetHomeCollectionByIdAsync(int homeCollectionId, CancellationToken token)
        {
            return await _dbContext.HomeCollections
                                    .Include(x => x.Gender)
                                    .SingleAsync(homeCollection => homeCollection.Id == homeCollectionId && homeCollection.IsActive, token);
        }
    }
}
