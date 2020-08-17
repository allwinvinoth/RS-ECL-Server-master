using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Data.Repositories
{
    public class SampleTypeRepository : ISampleTypeRepository
    {
        private readonly LISDbContext _dbContext;

        public SampleTypeRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SampleTypeEntity> CreateSampleTypeAsync(SampleTypeEntity sampleTypeEntity, CancellationToken token)
        {
            await _dbContext.SampleTypes.AddAsync(sampleTypeEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return sampleTypeEntity;
        }

        public async Task DeleteSampleTypeByIdAsync(int sampleTypeId, CancellationToken token)
        {
            var sampleTypeEntity = await _dbContext.SampleTypes.SingleAsync(sampleType => sampleType.Id == sampleTypeId && sampleType.IsActive, token);
            sampleTypeEntity.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SampleTypeEntity>> GetSampleTypeEntitiesAsync(CancellationToken token)
        {
            return await _dbContext.SampleTypes.Where(sampleType => sampleType.IsActive).ToListAsync(token);
        }

        public async Task<SampleTypeEntity> GetSampleTypeEntityByIdAsync(int sampleTypeId, CancellationToken token)
        {
            return await _dbContext.SampleTypes.SingleAsync(sampleType => sampleType.Id == sampleTypeId && sampleType.IsActive, token);
        }
    }
}
