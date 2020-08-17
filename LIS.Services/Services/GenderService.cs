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
    public sealed class GenderService:IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        private readonly IMapper _mapper;
        public GenderService(
           IGenderRepository genderRepository,
           IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }
        public async Task<GenderServiceObject> CreateGenderAsync(GenderServiceObject genderServiceObject, CancellationToken token)
        {
            var genderEntity = _mapper.Map<GenderEntity>(genderServiceObject);
            var createdEntity = await _genderRepository.CreateGenderAsync(genderEntity, token);
            return _mapper.Map<GenderServiceObject>(createdEntity);
        }
        public async Task<GenderServiceObject> GetGenderByIdAsync(int genderId, CancellationToken token)
        {
            var genderEntity = await _genderRepository.GetGenderByIdAsync(genderId, token);
            return _mapper.Map<GenderServiceObject>(genderEntity);
        }
        public async Task<IEnumerable<GenderServiceObject>> GetGenderListAsync(CancellationToken token)
        {
            var serviceResult = await _genderRepository.GetGenderListAsync(token);
            return _mapper.Map<IEnumerable<GenderServiceObject>>(serviceResult);
        }
        public async Task<GenderServiceObject> UpdateGenderByIdAsync(GenderServiceObject genderServiceObject, CancellationToken token)
        {
            var genderEntity = _mapper.Map<GenderEntity>(genderServiceObject);
            var updatedEntity = await _genderRepository.UpdateGenderByIdAsync(genderEntity, token);
            return _mapper.Map<GenderServiceObject>(updatedEntity);
        }
        public async Task DeleteGenderByIdAsync(int genderId, CancellationToken token)
        {
            await _genderRepository.DeleteGenderByIdAsync(genderId, token);
        }
    }
}
