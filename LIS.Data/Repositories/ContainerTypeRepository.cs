using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Data.Repositories
{
    public sealed class ContainerTypeRepository : IContainerTypeRepository
    {
        private readonly LISDbContext _dbContext;

        public ContainerTypeRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContainerTypeEntity> CreateContainerTypeAsync(ContainerTypeEntity containerTypeEntity, CancellationToken token)
        {
            await _dbContext.ContainerTypes.AddAsync(containerTypeEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return containerTypeEntity;
        }

        public async Task DeleteContainerTypeByIdAsync(int containerTypeId, CancellationToken token)
        {
            var containerTypeEntity = await _dbContext.ContainerTypes.SingleAsync(containerType => containerType.Id == containerTypeId && containerType.IsActive, token);
            containerTypeEntity.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ContainerTypeEntity> GetContainerTypeByIdAsync(int containerTypeId, CancellationToken token)
        {
            return await _dbContext.ContainerTypes.SingleAsync(containerType => containerType.Id == containerTypeId && containerType.IsActive, token);
        }

        public async Task<IEnumerable<ContainerTypeEntity>> GetContainerTypesAsync(CancellationToken token)
        {
            return await _dbContext.ContainerTypes.Where(containerType => containerType.IsActive).ToListAsync(token);
        }
    }
}
