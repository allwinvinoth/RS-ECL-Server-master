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
    public sealed class GenderRepository: IGenderRepository
    {
        private readonly LISDbContext _dbContext;

        public GenderRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GenderEntity> GetGenderByIdAsync(int id, CancellationToken token)
        {
            return await _dbContext.Genders
                                   .SingleAsync(gender => gender.Id == id && gender.IsActive, token);
        }

        public async Task<GenderEntity> CreateGenderAsync(GenderEntity genderEntity, CancellationToken token)
        {
            await _dbContext.Genders.AddAsync(genderEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return genderEntity;
        }

        public async Task<IEnumerable<GenderEntity>> GetGenderListAsync(CancellationToken token)
        {
            return await _dbContext.Genders
                                   .Where(gender => gender.IsActive).ToListAsync(token);
        }

        public async Task<GenderEntity> UpdateGenderByIdAsync(GenderEntity genderEntity, CancellationToken token)
        {
            _dbContext.Genders.Update(genderEntity);
            await _dbContext.SaveChangesAsync(token);
            return genderEntity;
        }

        public async Task DeleteGenderByIdAsync(int genderId, CancellationToken token)
        {
            var genderEntity = await _dbContext.Genders.SingleAsync(gender => gender.Id == genderId, token);
            genderEntity.IsActive = false;
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
