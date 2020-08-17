using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Tests.Request;
using LIS.API.DataTransferObjects.Tests.Response;
using LIS.Common.Exceptions;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace LIS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public sealed class TestsController : ApiController
    {
        private readonly ITestsService _testsService;
        
        private readonly IValidator<AddTestRequestDto> _addTestRequestValidator;
        
        private readonly IValidator<UpdateTestRequestDto> _updateTestRequestValidator;
        
        public TestsController(
            ITestsService testsService,
            IValidator<AddTestRequestDto> addTestRequestValidator,
            IValidator<UpdateTestRequestDto> updateTestRequestValidator,
            IMapper mapper): base(mapper)
        {
            _testsService = testsService;
            _addTestRequestValidator = addTestRequestValidator;
            _updateTestRequestValidator = updateTestRequestValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AddTestResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTestAsync(
            [FromBody] AddTestRequestDto addTestRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _addTestRequestValidator.ValidateAsync(addTestRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }
                
                var testServiceObject = Mapper.Map<TestServiceObject>(addTestRequestDto);
                var serviceResult = await _testsService.CreateTestAsync(testServiceObject, token);
                return new OkObjectResult(Mapper.Map<AddTestResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }
        
        [HttpGet("{testId}")]
        [ProducesResponseType(200, Type = typeof(GetTestResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTestByIdAsync(
            [FromRoute] long testId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _testsService.GetTestByIdAsync(testId, token);
                return new OkObjectResult(Mapper.Map<GetTestResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetTestResponseDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTestsByDepartmentIdAsync(
            [FromQuery] int departmentId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _testsService.GetTestsByDepartmentIdAsync(departmentId, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetTestResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }


        [HttpPut("{testId}")]
        [ProducesResponseType(200, Type = typeof(UpdateTestResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTestByIdAsync(
            [FromRoute] long testId,
            [FromBody] UpdateTestRequestDto updateTestRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updateTestRequestValidator.ValidateAsync(updateTestRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var testServiceObject = Mapper.Map<TestServiceObject>(updateTestRequestDto);
                testServiceObject.Id = testId;
                var serviceResult = await _testsService.UpdateTestAsync(testServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateTestResponseDto>(serviceResult));
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

        [HttpDelete("{testId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTestByIdAsync(
            [FromRoute] long testId,
            CancellationToken token = default)
        {
            try
            {
                await _testsService.DeleteTestByIdAsync(testId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetTestResponseDto>))]
        [ProducesResponseType(400)]
        [Route("search")]
        public async Task<IActionResult> SearchTestAsync(
            [FromQuery] string name,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _testsService.GetTestsByNameAsync(name, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetTestResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new OkObjectResult(Enumerable.Empty<string>());
            }
        }
    }
}