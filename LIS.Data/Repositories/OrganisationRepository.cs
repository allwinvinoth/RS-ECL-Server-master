using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using LIS.DataContracts.Entities;
using Microsoft.EntityFrameworkCore;
using LIS.DataContracts.Repositories;

namespace LIS.Data.Repositories
{
    public sealed class OrganisationRepository : IOrganisationRepository
    {
        private readonly LISDbContext _dbContext;

        public OrganisationRepository(LISDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OrganisationEntity> AddOrganisationAsync(
            OrganisationEntity organisationEntity, 
            CancellationToken token)
        {
            await _dbContext.Organisations.AddAsync(organisationEntity, token);
            await _dbContext.SaveChangesAsync(token);
            return organisationEntity;
        }

        public async Task<IEnumerable<OrganisationEntity>> GetOrganisationsAsync(CancellationToken token)
        {
            return await _dbContext.Organisations
                                   .Where(organisation => organisation.IsActive).ToListAsync(token);
        }

        public async Task<OrganisationEntity> GetOrganisationByIdAsync(
            int organisationId, 
            CancellationToken token)
        {
            return await _dbContext.Organisations
                                   .SingleAsync(organisation => organisation.Id == organisationId && organisation.IsActive, token);
        }
        
        public async Task<OrganisationEntity> UpdateOrganisationByIdAsync(
            OrganisationEntity organisationEntity, 
            CancellationToken token)
        {
            _dbContext.Organisations.Update(organisationEntity);
            await this._dbContext.SaveChangesAsync(token);
            return organisationEntity;
        }

        public async Task<OrganisationEntity> DeleteOrganisationByIdAsync(int organisationId, CancellationToken token)
        {
            var organisationEntity = _dbContext.Organisations.First(organisation => organisation.Id == organisationId && organisation.IsActive);
            organisationEntity.IsActive = false;
            await _dbContext.SaveChangesAsync();
            return organisationEntity;

        }
    }
}
