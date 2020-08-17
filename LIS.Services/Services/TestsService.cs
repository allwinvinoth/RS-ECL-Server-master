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
    public sealed class TestsService : ITestsService
    {
        private readonly ITestRepository _testRepository;

        private readonly IMapper _mapper;

        private readonly ISaveTestValidationService _saveTestValidationService;

        public TestsService(
            ISaveTestValidationService saveTestValidationService,
            ITestRepository testRepository,
            IMapper mapper)
        {
            _saveTestValidationService = saveTestValidationService;
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<TestServiceObject> CreateTestAsync(TestServiceObject testServiceObject, CancellationToken token)
        {
            await _saveTestValidationService.Validate(testServiceObject, token);
            var testEntity = _mapper.Map<TestEntity>(testServiceObject);
            var createdEntity = await _testRepository.CreateTestAsync(testEntity, token);
            return _mapper.Map<TestServiceObject>(createdEntity);
        }

        public async Task<TestServiceObject> GetTestByIdAsync(long testId, CancellationToken token)
        {
            var testEntity = await _testRepository.GetTestByIdAsync(testId, token);
            return _mapper.Map<TestServiceObject>(testEntity);
        }

        public async Task<IEnumerable<TestServiceObject>> GetTestsByDepartmentIdAsync(int departmentId, CancellationToken token)
        {
            var testEntities = await _testRepository.GetTestsByDepartmentIdAsync(departmentId, token);
            return _mapper.Map<IEnumerable<TestServiceObject>>(testEntities);
        }

        public async Task<TestServiceObject> UpdateTestAsync(TestServiceObject testServiceObject, CancellationToken token)
        {
            await _saveTestValidationService.Validate(testServiceObject, token);
            var testEntity = _mapper.Map<TestEntity>(testServiceObject);
            var updatedEntity = await _testRepository.UpdateTestAsync(testEntity, token);
            return _mapper.Map<TestServiceObject>(updatedEntity);
        }

        public async Task DeleteTestByIdAsync(long testId, CancellationToken token)
        {
            await _testRepository.DeleteTestByIdAsync(testId, token);
        }

        public async Task<IEnumerable<TestServiceObject>> GetTestsByNameAsync(string testName, CancellationToken token)
        {
            var testEntity = await _testRepository.GetTestsByNameAsync(testName, token);
            return _mapper.Map<IEnumerable<TestServiceObject>>(testEntity);
        }
    }
}