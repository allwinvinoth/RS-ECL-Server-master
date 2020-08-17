using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using LIS.ServiceContracts.Validations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Services.Services
{
    public class SampleService : ISampleService
    {
        private readonly IMapper _mapper;
        private readonly ISampleRepository _sampleRepository;
        private readonly ISaveSampleValidationService _saveSampleValidationService;

        public SampleService(ISampleRepository sampleRepository, ISaveSampleValidationService saveSampleValidationService, IMapper mapper)
        {
            _sampleRepository = sampleRepository;
            _saveSampleValidationService = saveSampleValidationService;
            _mapper = mapper;
        }

        public async Task<SampleServiceObject> CreateSampleAsync(SampleServiceObject sampleobject, CancellationToken token)
        {
            await _saveSampleValidationService.Validate(sampleobject, token);

            var sampleEntity = _mapper.Map<SampleEntity>(sampleobject);
            var createdEntity = await _sampleRepository.CreateSampleAsync(sampleEntity, token);
            return _mapper.Map<SampleServiceObject>(createdEntity);
        }
        
        public async Task<SampleServiceObject> GetSampleByIdAsync(int sampleId, CancellationToken token)
        {
            var serviceResult = await _sampleRepository.GetSampleByIdAsync(sampleId, token);
            return _mapper.Map<SampleServiceObject>(serviceResult);
        }

        public async Task<IEnumerable<SampleServiceObject>> GetSamplesAsync(CancellationToken token)
        {
            var serviceResult = await _sampleRepository.GetSamplesAsync(token);
            return _mapper.Map<IEnumerable<SampleServiceObject>>(serviceResult);
        }

        public async Task<SampleServiceObject> UpdateSampleAsync(SampleServiceObject sampleObject, CancellationToken token)
        {
            await _saveSampleValidationService.Validate(sampleObject, token);

            var sampleEntity = _mapper.Map<SampleEntity>(sampleObject);
            var updatedEntity = await _sampleRepository.UpdateSampleAsync(sampleEntity, token);
            return _mapper.Map<SampleServiceObject>(updatedEntity);
        }

        public async Task DeleteSampleByIdAsync(int sampleId, CancellationToken token)
        {
            await _sampleRepository.DeleteSampleByIdAsync(sampleId, token);
        }

    }
}
