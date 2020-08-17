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
    public class HomeCollectionService : IHomeCollectionService
    {
        private readonly IMapper _mapper;
        private readonly IHomeCollectionRepository _homeCollectionRepository;

        public HomeCollectionService(IHomeCollectionRepository homeCollectionRepository, IMapper mapper)
        {
            _homeCollectionRepository = homeCollectionRepository;
            _mapper = mapper;
        }

        public async Task<HomeCollectionServiceObject> CreateHomeCollectionAsync(HomeCollectionServiceObject homeCollectionServiceObject, CancellationToken token)
        {
            var homeCollectionEntity = this._mapper.Map<HomeCollectionEntity>(homeCollectionServiceObject);
            var createdEntity = await _homeCollectionRepository.CreateHomeCollectionAsync(homeCollectionEntity, token);
            return this._mapper.Map<HomeCollectionServiceObject>(createdEntity);
        }

        public async Task<HomeCollectionServiceObject> UpdateHomeCollectionByIdAsync(HomeCollectionServiceObject homeCollectionServiceObject, CancellationToken token)
        {
            var homeCollectionEntity = this._mapper.Map<HomeCollectionEntity>(homeCollectionServiceObject);
            var updatedEntity = await _homeCollectionRepository.UpdateHomeCollectionByIdAsync(homeCollectionEntity, token);
            return this._mapper.Map<HomeCollectionServiceObject>(updatedEntity);
        }

        public async Task DeleteHomeCollectionByIdAsync(int homeCollectionId, CancellationToken token)
        {
            await _homeCollectionRepository.DeleteHomeCollectionByIdAsync(homeCollectionId, token);
        }

        public async Task<IEnumerable<HomeCollectionServiceObject>> GetAllHomeCollectionsAsync(CancellationToken token)
        {
            var serviceResult = await _homeCollectionRepository.GetAllHomeCollectionsAsync(token);
            return this._mapper.Map<IEnumerable<HomeCollectionServiceObject>>(serviceResult);
        }

        public async Task<HomeCollectionServiceObject> GetHomeCollectionByIdAsync(int homeCollectionId, CancellationToken token)
        {
            var homeCollectionEntity = await _homeCollectionRepository.GetHomeCollectionByIdAsync(homeCollectionId, token);
            return this._mapper.Map<HomeCollectionServiceObject>(homeCollectionEntity);
        }
    }
}
