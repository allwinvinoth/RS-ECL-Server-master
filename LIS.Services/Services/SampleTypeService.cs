using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Services.Services
{
    public class SampleTypeService : ISampleTypeService
    {
        private readonly IMapper _mapper;
        private readonly ISampleTypeRepository _sampleTypeRepository;

        public SampleTypeService(ISampleTypeRepository sampleTypeRepository, IMapper mapper)
        {
            _sampleTypeRepository = sampleTypeRepository;
            _mapper = mapper;
        }

        public async Task<SampleTypeServiceObject> CreateSampleTypeAsync(SampleTypeServiceObject sampleTypeServiceObject, CancellationToken token)
        {
            var sampleTypeEntity = _mapper.Map<SampleTypeEntity>(sampleTypeServiceObject);
            var createdEntity = await _sampleTypeRepository.CreateSampleTypeAsync(sampleTypeEntity, token);
            return _mapper.Map<SampleTypeServiceObject>(createdEntity);
        }

        public async Task DeleteSampleTypeByIdAsync(int sampleTypeId, CancellationToken token)
        {
            await _sampleTypeRepository.DeleteSampleTypeByIdAsync(sampleTypeId, token);
        }

        public async Task<IEnumerable<SampleTypeServiceObject>> GetSampleTypesAsync(CancellationToken token)
        {
            var serviceResult = await _sampleTypeRepository.GetSampleTypeEntitiesAsync(token);
            return _mapper.Map<IEnumerable<SampleTypeServiceObject>>(serviceResult);
        }

        public async Task<SampleTypeServiceObject> GetSampleTypeByIdAsync(int sampleTypeId, CancellationToken token)
        {
            var serviceResult = await _sampleTypeRepository.GetSampleTypeEntityByIdAsync(sampleTypeId ,token);
            return _mapper.Map<SampleTypeServiceObject>(serviceResult);
        }
    }
}
