using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Services.Services
{
    public sealed class OrganisationService : IOrganisationService
    {
        private readonly IMapper _mapper;
        
        private readonly IOrganisationRepository _organisationRepository;

        public OrganisationService(
            IOrganisationRepository organisationRepository, 
            IMapper mapper)
        {
            _organisationRepository = organisationRepository;
            _mapper = mapper;
        }
        public async Task<OrganisationServiceObject> AddOrganisationAsync(
            OrganisationServiceObject organisationServiceObject,
            CancellationToken token)
        {
            var organisationEntity = _mapper.Map<OrganisationEntity>(organisationServiceObject);
            var createdEntity = await _organisationRepository.AddOrganisationAsync(organisationEntity, token);
            return _mapper.Map<OrganisationServiceObject>(createdEntity);
        }

        public async Task<IEnumerable<OrganisationServiceObject>> GetOrganisationsAsync(CancellationToken token)
        {
            var serviceResult = await _organisationRepository.GetOrganisationsAsync(token);
            return _mapper.Map<IEnumerable<OrganisationServiceObject>>(serviceResult);
        }

        public async Task<OrganisationServiceObject> GetOrganisationByIdAsync(
            int organisationId,
            CancellationToken token)
        {
            var serviceResult = await _organisationRepository.GetOrganisationByIdAsync(organisationId, token);
            return _mapper.Map<OrganisationServiceObject>(serviceResult);
        }
        
        public async Task<OrganisationServiceObject> UpdateOrganisationByIdAsync(
            OrganisationServiceObject organisationServiceObject,
            CancellationToken token)
        {
            var organisationEntity = _mapper.Map<OrganisationEntity>(organisationServiceObject);
            var updatedEntity = await _organisationRepository.UpdateOrganisationByIdAsync(organisationEntity, token);
            return _mapper.Map<OrganisationServiceObject>(updatedEntity);
        }

        public async Task<OrganisationServiceObject> DeleteOrganisationByIdAsync(int organisationId,CancellationToken token)
        {
            var serviceResult = await _organisationRepository.DeleteOrganisationByIdAsync(organisationId, token);
            return _mapper.Map<OrganisationServiceObject>(serviceResult);
        }
    }
}
