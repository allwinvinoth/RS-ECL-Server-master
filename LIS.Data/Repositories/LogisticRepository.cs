using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Data.Repositories
{
    public sealed class LogisticRepository : ILogisticRepository
    {
        private readonly LISDbContext _dbContext;

        public LogisticRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LogisticEntity> CreateLogisticAsync(LogisticEntity logisticEntity, CancellationToken token)
        {
            await _dbContext.Logistics.AddAsync(logisticEntity, token);
            await _dbContext.SaveChangesAsync(token);

            return await _dbContext.Logistics
                                   .Include(logistic => logistic.Driver)
                                   .Include(logistic => logistic.LogisticAndLogisticTypes)
                                   .ThenInclude(logisticTypeEntity => logisticTypeEntity.LogisticType)
                                   .Include(logistic => logistic.LogisticSpecimenTypes)
                                   .ThenInclude(logisticTypeEntity => logisticTypeEntity.SpecimenType)
                                   .SingleAsync(logistic => logistic.Id == logisticEntity.Id, token);
        }

        public async Task<LogisticEntity> UpdateLogisticByIdAsync(LogisticEntity logisticEntity, CancellationToken token)
        {
            _dbContext.LogisticAndLogisticTypes.RemoveRange(_dbContext.LogisticAndLogisticTypes
                                   .Include(logisticTypeEntity => logisticTypeEntity.LogisticType)
                                   .Where(logisticTypeEntity => logisticTypeEntity.LogisticId == logisticEntity.Id).ToList());
            
            _dbContext.LogisticAndSpecimenTypes.RemoveRange(_dbContext.LogisticAndSpecimenTypes
                                   .Include(logisticTypeEntity => logisticTypeEntity.SpecimenType)
                                   .Where(logisticTypeEntity => logisticTypeEntity.LogisticId == logisticEntity.Id).ToList());

            _dbContext.Logistics.Update(logisticEntity);
            await _dbContext.SaveChangesAsync(token);
            return await _dbContext.Logistics
                                   .Include(logistic => logistic.Driver)
                                   .Include(logistic => logistic.LogisticAndLogisticTypes)
                                   .ThenInclude(logisticTypeEntity => logisticTypeEntity.LogisticType)
                                   .SingleAsync(logistic => logistic.Id == logisticEntity.Id, token);
        }

        public async Task DeleteLogisticByIdAsync(int logisticId, CancellationToken token)
        {
            var logisticEntity = await _dbContext.Logistics.SingleAsync(logistic => logistic.Id == logisticId, token);
            logisticEntity.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<LogisticEntity>> GetAllLogisticsAsync(CancellationToken token)
        {
            return await _dbContext.Logistics
                                    .Include(x => x.Driver)
                                    .Include(logistic => logistic.LogisticAndLogisticTypes)
                                    .ThenInclude(logisticTypeEntity => logisticTypeEntity.LogisticType)
                                    .Include(logistic => logistic.LogisticSpecimenTypes)
                                   .ThenInclude(logisticTypeEntity => logisticTypeEntity.SpecimenType)
                                    .Where(logistic => logistic.IsActive).ToListAsync(token);
        }

        public async Task<LogisticEntity> GetLogisticByIdAsync(int logisticId, CancellationToken token)
        {
            return await _dbContext.Logistics
                                    .Include(x => x.Driver)
                                    .Include(logistic => logistic.LogisticAndLogisticTypes)
                                    .ThenInclude(logisticTypeEntity => logisticTypeEntity.LogisticType)
                                    .Include(logistic => logistic.LogisticSpecimenTypes)
                                   .ThenInclude(logisticTypeEntity => logisticTypeEntity.SpecimenType)
                                    .SingleAsync(logistic => logistic.Id == logisticId && logistic.IsActive, token);
        }
    }
}
