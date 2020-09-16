using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace LIS.Data.Repositories
{
    public sealed class EquipmentRepository : IEquipmentRepository
    {
        private readonly LISDbContext _dbContext;

        public EquipmentRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<EquipmentEntity> GetEquipmentById(int id, CancellationToken token)
        {
            return await _dbContext.Equipments
                                   .SingleAsync(Equipment => Equipment.Id == id && Equipment.IsActive, token);
        }

        public async Task<EquipmentEntity> CreateEquipmentAsync(EquipmentEntity EquipmentEntity, CancellationToken token)
        {
            EquipmentEntity.IsActive = true;
            await _dbContext.Equipments.AddAsync(EquipmentEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return EquipmentEntity;
        }

        public async Task<IEnumerable<EquipmentEntity>> GetEquipmentsByBranchIdAsync(int branchId, CancellationToken token)
        {
            return await _dbContext.Equipments.Where(Equipment => Equipment.IsActive).ToListAsync(token);
        }

        public async Task<IEnumerable<EquipmentEntity>> GetAll(CancellationToken token)
        {
            try
            {
                return await _dbContext.Equipments.Where(Equipment => Equipment.IsActive).ToListAsync(token);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<EquipmentEntity> UpdateEquipmentAsync(EquipmentEntity EquipmentEntity, CancellationToken token)
        {
            _dbContext.Equipments.Update(EquipmentEntity);
            await _dbContext.SaveChangesAsync(token);
            return EquipmentEntity;
        }

        public async Task DeleteEquipmentByIdAsync(int EquipmentId, CancellationToken token)
        {
            var EquipmentEntity =await _dbContext.Equipments.SingleAsync(Equipment => Equipment.Id == EquipmentId && Equipment.IsActive,token);
            EquipmentEntity.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }
    }
}