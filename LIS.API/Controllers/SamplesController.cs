using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Samples.Request;
using LIS.API.DataTransferObjects.Samples.Response;
using LIS.ServiceContracts.Services;
using LIS.Common.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using LIS.ServiceContracts.ServiceObjects;
using System.Collections.Generic;
using LIS.Common.Exceptions;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SamplesController : ApiController
    {
        private readonly ISampleService _sampleService;
        private readonly IValidator<CreateSampleRequestDto> _createSampleRequestDtoValidator;
        private readonly IValidator<UpdateSampleRequestDto> _updateSampleRequestDtoValidator;

        public SamplesController(ISampleService sampleService,
            IValidator<CreateSampleRequestDto> createSampleRequestDtoValidator,
            IValidator<UpdateSampleRequestDto> updateSampleRequestDtoValidator,
            IMapper mapper) : base(mapper)
        {
            _sampleService = sampleService;
            _createSampleRequestDtoValidator = createSampleRequestDtoValidator;
            _updateSampleRequestDtoValidator = updateSampleRequestDtoValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateSampleResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSampleTypeAsync([FromBody] CreateSampleRequestDto createSampleRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _createSampleRequestDtoValidator.ValidateAsync(createSampleRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());

                var sampleServiceObject = Mapper.Map<SampleServiceObject>(createSampleRequestDto);
                var serviceResponse = await _sampleService.CreateSampleAsync(sampleServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreateSampleResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpPut("{sampleId}")]
        [ProducesResponseType(200, Type = typeof(UpdateSampleResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSampleAsync(
            [FromRoute] int sampleId,
            [FromBody] UpdateSampleRequestDto updateSampleRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updateSampleRequestDtoValidator.ValidateAsync(updateSampleRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());

                var sampleServiceObject = Mapper.Map<SampleServiceObject>(updateSampleRequestDto);
                sampleServiceObject.Id = sampleId;

                var serviceResponse = await _sampleService.UpdateSampleAsync(sampleServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateSampleResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetSampleResponseDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSamplesAsync(CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _sampleService.GetSamplesAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetSampleResponseDto>>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{sampleId}")]
        [ProducesResponseType(200, Type = typeof(GetSampleResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSampleByIdAsync([FromRoute] int sampleId, CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _sampleService.GetSampleByIdAsync(sampleId, token);
                return new OkObjectResult(Mapper.Map<GetSampleResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpDelete("{sampleId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteSampleByIdAsync([FromRoute] int sampleId, CancellationToken token = default)
        {
            try
            {
                await _sampleService.DeleteSampleByIdAsync(sampleId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}