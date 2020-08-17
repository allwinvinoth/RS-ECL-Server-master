using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Data.Repositories
{
    public sealed class SampleRepository : ISampleRepository
    {
        private readonly LISDbContext _dbContext;

        public SampleRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SampleEntity> CreateSampleAsync(SampleEntity sampleEntity, CancellationToken token)
        {
            await _dbContext.Samples.AddAsync(sampleEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return sampleEntity;
        }        

        public async Task<SampleEntity> GetSampleByIdAsync(int sampleId, CancellationToken token)
        {
            return await _dbContext.Samples
                                   .Include(x => x.SampleType)
                                   .Include(x => x.ContainerType)
                                   .SingleAsync(sample => sample.Id == sampleId && sample.IsActive, token);
        }

        public async Task<IEnumerable<SampleEntity>> GetSamplesAsync(CancellationToken token)
        {
            return await _dbContext.Samples
                                   .Include(x => x.SampleType)
                                   .Include(x => x.ContainerType)
                                   .Where(sample => sample.IsActive).ToListAsync(token);
        }

        public async Task<SampleEntity> UpdateSampleAsync(SampleEntity sampleEntity, CancellationToken token)
        {
            _dbContext.Samples.Update(sampleEntity);
            await _dbContext.SaveChangesAsync(token);
            return sampleEntity;
        }

        public async Task DeleteSampleByIdAsync(int sampleId, CancellationToken token)
        {
            var sampleEntity = await _dbContext.Samples.SingleAsync(sample => sample.Id == sampleId && sample.IsActive, token);
            sampleEntity.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }
    }
}
