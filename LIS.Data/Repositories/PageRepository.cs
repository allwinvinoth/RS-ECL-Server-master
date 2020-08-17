using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LIS.Data.Repositories
{
    public sealed class PageRepository : IPageRepository
    {
        private readonly LISDbContext _dbContext;
        public PageRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PageEntity> CreatePageAsync(PageEntity pageEntity, CancellationToken token)
        {
            await _dbContext.Pages.AddAsync(pageEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return pageEntity;
        }

        public async Task<IEnumerable<PageEntity>> GetAllPagesForOrganisationAsync(int organisationId, CancellationToken token)
        {
            return await _dbContext.Pages.Where(page => page.OrganisationId == organisationId && page.IsActive).ToListAsync(token);
        }

        public async Task<PageEntity> UpdatePageAsync(PageEntity pageEntity, CancellationToken token)
        {
            _dbContext.Pages.Update(pageEntity);
            await _dbContext.SaveChangesAsync(token);
            return pageEntity;
        }
    }
}