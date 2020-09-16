using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LIS.Data.Repositories
{
    public sealed class MethodRepository : IMethodRepository
    {
        private readonly LISDbContext _dbContext;

        public MethodRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<MethodEntity> GetMethodById(int id, CancellationToken token)
        {
            return await _dbContext.Methods
                                   .SingleAsync(method => method.Id == id && method.IsActive, token);
        }

        public async Task<MethodEntity> CreateMethodAsync(MethodEntity methodEntity, CancellationToken token)
        {
            await _dbContext.Methods.AddAsync(methodEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return methodEntity;
        }

        public async Task<IEnumerable<MethodEntity>> GetMethodsByBranchIdAsync(int departmentId, CancellationToken token)
        {
            return await _dbContext.Methods.Where(method => method.departmentId == departmentId && method.IsActive).ToListAsync(token);
        }

        public async Task<IEnumerable<MethodEntity>> GetAll(CancellationToken token)
        {
            return await _dbContext.Methods.Where(method => method.IsActive).Include(x=>x.department).ToListAsync(token);
        }
        public async Task<MethodEntity> UpdateMethodAsync(MethodEntity methodEntity, CancellationToken token)
        {
            _dbContext.Methods.Update(methodEntity);
            await _dbContext.SaveChangesAsync(token);
            return methodEntity;
        }

        public async Task DeleteMethodByIdAsync(int methodId, CancellationToken token)
        {
            var methodEntity =await _dbContext.Methods.SingleAsync(method => method.Id == methodId && method.IsActive,token);
            methodEntity.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }
    }
}