
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.TestProfiles.Request;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.Common.Exceptions;
using System;
using System.Collections.Generic;
using LIS.API.DataTransferObjects.TestProfiles.Response;

namespace LIS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public sealed class TestProfilesController : ApiController
    {
        private readonly ITestProfilesService _testProfilesService;

        private readonly IValidator<CreateTestProfileRequestDto> _createTestProfileRequestValidator;

        private readonly IValidator<UpdateTestProfileRequestDto> _updateTestProfileRequestValidator;

        public TestProfilesController(
            ITestProfilesService testProfilesService,
            IValidator<CreateTestProfileRequestDto> createTestProfileRequestValidator,
            IValidator<UpdateTestProfileRequestDto> updateTestProfileRequestValidator,
            IMapper mapper) : base(mapper)
        {
            _testProfilesService = testProfilesService;
            _createTestProfileRequestValidator = createTestProfileRequestValidator;
            _updateTestProfileRequestValidator = updateTestProfileRequestValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateTestProfileResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTestProfileAsync(
            [FromBody] CreateTestProfileRequestDto createTestProfileRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _createTestProfileRequestValidator.ValidateAsync(createTestProfileRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var testServiceObject = Mapper.Map<TestProfileServiceObject>(createTestProfileRequestDto);
                var serviceResult = await _testProfilesService.CreateTestProfileAsync(testServiceObject, token);
                return new OkObjectResult(Mapper.Map<CreateTestProfileResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpGet("{testProfileId}")]
        [ProducesResponseType(200, Type = typeof(GetTestProfileResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTestProfileByIdAsync(
            [FromRoute] long testProfileId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _testProfilesService.GetTestProfileByIdAsync(testProfileId, token);
                return new OkObjectResult(Mapper.Map<GetTestProfileResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetTestProfileResponseDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllTestProfileAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _testProfilesService.GetAllTestProfileAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetTestProfileResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }


        [HttpPut("{testProfileId}")]
        [ProducesResponseType(200, Type = typeof(UpdateTestProfileResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTestProfileByIdAsync(
            [FromRoute] long testProfileId,
            [FromBody] UpdateTestProfileRequestDto updateTestProfileRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updateTestProfileRequestValidator.ValidateAsync(updateTestProfileRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var testProfileServiceObject = Mapper.Map<TestProfileServiceObject>(updateTestProfileRequestDto);
                testProfileServiceObject.Id = testProfileId;
                var serviceResult = await _testProfilesService.UpdateTestProfileAsync(testProfileServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateTestProfileResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{testProfileId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTestProfileByIdAsync(
            [FromRoute] long testProfileId,
            CancellationToken token = default)
        {
            try
            {
                await _testProfilesService.DeleteTestProfileByIdAsync(testProfileId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}