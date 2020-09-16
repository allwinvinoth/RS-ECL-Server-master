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
    public sealed class IndividualTestMasterService : IIndividualTestMasterService
    {
        private readonly IMapper _mapper;
        private readonly IIndividualTestMasterRepository _individualTestMasterRepository;
        public IndividualTestMasterService(IIndividualTestMasterRepository individualTestMasterRepository, IMapper mapper)
        {
            _individualTestMasterRepository = individualTestMasterRepository;
            _mapper = mapper;
        }
        public async Task<IndividualTestServiceObject> CreateIndividualTestMasterAsync(IndividualTestServiceObject individualTestMasterServiceObject, CancellationToken token)
        {
            var individualTestMasterEntity = _mapper.Map<IndividualTestEntity>(individualTestMasterServiceObject);
            var createdEntity = await _individualTestMasterRepository.CreateIndividualTestMasterAsync(individualTestMasterEntity, token);
            return _mapper.Map<IndividualTestServiceObject>(createdEntity);
        }

        public async Task<IEnumerable<IndividualTestServiceObject>> GetAll(CancellationToken token)
        {
            var serviceResult = await _individualTestMasterRepository.GetAll(token);
            return _mapper.Map<IEnumerable<IndividualTestServiceObject>>(serviceResult);
        }
        public async Task<IndividualTestServiceObject> UpdateIndividualTestMasterAsync(IndividualTestServiceObject individualTestMasterServiceObject, CancellationToken token)
        {
            var individualTestMasterEntity = _mapper.Map<IndividualTestEntity>(individualTestMasterServiceObject);
            var updatedEntity = await _individualTestMasterRepository.UpdateIndividualTestMasterAsync(individualTestMasterEntity, token);
            return _mapper.Map<IndividualTestServiceObject>(updatedEntity);
        }
        public async Task DeleteIndividualTestMasterByIdAsync(int individualTestMasterId, CancellationToken token)
        {
            await _individualTestMasterRepository.DeleteIndividualTestMasterByIdAsync(individualTestMasterId, token);
        }
    }
}
