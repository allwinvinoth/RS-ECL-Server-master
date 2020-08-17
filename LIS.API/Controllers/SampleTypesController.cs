using AutoMapper;
using LIS.API.DataTransferObjects.SampleTypes.Request;
using LIS.API.DataTransferObjects.SampleTypes.Response;
using LIS.ServiceContracts.Services;
using LIS.Common.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using LIS.ServiceContracts.ServiceObjects;
using System.Collections.Generic;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SampleTypesController : ApiController
    {
        private readonly ISampleTypeService _sampleTypeService;
        private readonly IValidator<CreateSampleTypeRequestDto> _createSampleTypeRequestDtoValidator;

        public SampleTypesController(ISampleTypeService sampleTypeService,
            IValidator<CreateSampleTypeRequestDto> createSampleTypeRequestDtoValidator,
            IMapper mapper) : base(mapper)
        {
            _sampleTypeService = sampleTypeService;
            _createSampleTypeRequestDtoValidator = createSampleTypeRequestDtoValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateSampleTypeResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSampleTypeAsync([FromBody] CreateSampleTypeRequestDto createSampleTypeRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _createSampleTypeRequestDtoValidator.ValidateAsync(createSampleTypeRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());

                var sampleTypeServiceObject = Mapper.Map<SampleTypeServiceObject>(createSampleTypeRequestDto);
                var serviceResponse = await _sampleTypeService.CreateSampleTypeAsync(sampleTypeServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreateSampleTypeResponseDto>(serviceResponse));
            }
            catch(Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetSampleTypeResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSampleTypesAsync(CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _sampleTypeService.GetSampleTypesAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetSampleTypeResponseDto>>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{sampleTypeId}")]
        [ProducesResponseType(200, Type = typeof(GetSampleTypeResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSampleTypeByIdAsync([FromRoute] int sampleTypeId, CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _sampleTypeService.GetSampleTypeByIdAsync(sampleTypeId, token);
                return new OkObjectResult(Mapper.Map<GetSampleTypeResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpDelete("{sampleTypeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteSampleTypeByIdAsync(
            [FromRoute] int sampleTypeId,
            CancellationToken token = default)
        {
            try
            {
                await _sampleTypeService.DeleteSampleTypeByIdAsync(sampleTypeId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}