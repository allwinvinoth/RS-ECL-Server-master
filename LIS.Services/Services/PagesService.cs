using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using LIS.ServiceContracts.Validations;

namespace LIS.Services.Services
{
    public sealed class PagesService : IPagesService
    {
        private readonly IPageRepository _pageRepository;
        private readonly IMapper _mapper;
        private readonly ISavePageValidationService _savePageValidationService;
        public PagesService(IPageRepository pageRepository, IMapper mapper, ISavePageValidationService savePageValidationService)
        {
            _pageRepository = pageRepository;
            _mapper = mapper;
            _savePageValidationService = savePageValidationService;
        }
        public async Task<PageServiceObject> CreatePageAsync(PageServiceObject pageServiceObject, CancellationToken token)
        {
            await _savePageValidationService.Validate(pageServiceObject, token);
            var pageEntity = _mapper.Map<PageEntity>(pageServiceObject);
            var createdEntity = await _pageRepository.CreatePageAsync(pageEntity, token);
            return _mapper.Map<PageServiceObject>(createdEntity);
        }

        public async Task<IEnumerable<PageServiceObject>> GetAllPagesForOrganisationAsync(int organisationId, CancellationToken token)
        {
            var serviceResult = await _pageRepository.GetAllPagesForOrganisationAsync(organisationId, token);
            return _mapper.Map<IEnumerable<PageServiceObject>>(serviceResult);
        }

        public async Task<PageServiceObject> UpdatePageAsync(PageServiceObject pageServiceObject, CancellationToken token)
        {
            await _savePageValidationService.Validate(pageServiceObject, token);
            var pageEntity = _mapper.Map<PageEntity>(pageServiceObject);
            var updatedEntity = await _pageRepository.UpdatePageAsync(pageEntity, token);
            return _mapper.Map<PageServiceObject>(updatedEntity);
        }
    }
}