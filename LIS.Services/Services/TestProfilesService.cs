using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.DataContracts.Entities;
using LIS.DataContracts.Repositories;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;

namespace LIS.Services.Services
{
    public sealed class TestProfilesService : ITestProfilesService
    {
        private readonly ITestProfileRepository _testProfileRepository;

        private readonly IMapper _mapper;

        public TestProfilesService(ITestProfileRepository testProfileRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _testProfileRepository = testProfileRepository;
        }
        public async Task<TestProfileServiceObject> CreateTestProfileAsync(TestProfileServiceObject testProfileServiceObject, CancellationToken token)
        {
            var testProfileEntity = _mapper.Map<TestProfileEntity>(testProfileServiceObject);
            var createdEntity = await _testProfileRepository.CreateTestProfileAsync(testProfileEntity, token);
            return _mapper.Map<TestProfileServiceObject>(createdEntity);
        }

        public async Task<TestProfileServiceObject> UpdateTestProfileAsync(TestProfileServiceObject testProfileServiceObject, CancellationToken token)
        {
            var testProfileEntity = _mapper.Map<TestProfileEntity>(testProfileServiceObject);
            var updatedEntity = await _testProfileRepository.UpdateTestProfileAsync(testProfileEntity, token);
            return _mapper.Map<TestProfileServiceObject>(updatedEntity);
        }

        public async Task DeleteTestProfileByIdAsync(long testProfileId, CancellationToken token)
        {
            await _testProfileRepository.DeleteTestProfileByIdAsync(testProfileId, token);
        }

        public async Task<IEnumerable<TestProfileServiceObject>> GetAllTestProfileAsync(CancellationToken token)
        {
            var testProfileEntity = await _testProfileRepository.GetAllTestProfileAsync(token);
            return _mapper.Map<IEnumerable<TestProfileServiceObject>>(testProfileEntity);
        }

        public async Task<TestProfileServiceObject> GetTestProfileByIdAsync(long testProfileId, CancellationToken token)
        {
            var testProfileEntity = await _testProfileRepository.GetTestProfileByIdAsync(testProfileId, token);
            return _mapper.Map<TestProfileServiceObject>(testProfileEntity);
        }
    }
}