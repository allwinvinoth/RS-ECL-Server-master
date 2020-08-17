using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Patients.Request;
using LIS.API.DataTransferObjects.Patients.Response;
using LIS.Common.Exceptions;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    public sealed class PatientsController : ApiController
    {
        private readonly IValidator<CreatePatientRequestDto> _createPatientRequestDtoValidator;

        private readonly IPatientsService _patientsService;

        public PatientsController(
            IPatientsService patientsService,
            IValidator<CreatePatientRequestDto> createPatientRequestDtoValidator,
            IMapper mapper) : base(mapper)
        {
            _patientsService = patientsService;
            _createPatientRequestDtoValidator = createPatientRequestDtoValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreatePatientResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreatePatientAsync(
            [FromBody] CreatePatientRequestDto createPatientRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _createPatientRequestDtoValidator.ValidateAsync(createPatientRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var patientServiceObject = Mapper.Map<UserServiceObject>(createPatientRequestDto);
                var serviceResponse = await _patientsService.CreatePatientAsync(patientServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreatePatientResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpGet]
        [ProducesResponseType(201, Type = typeof(GetPatientResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPatientByIdAsync(
            [FromQuery] int patientId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _patientsService.GetPatientByIdAsync(patientId, token);
                return new OkObjectResult(Mapper.Map<GetPatientResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(GetPatientResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPatientAsync(
            [FromQuery] string searchQuery,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _patientsService.SearchPatientAsync(searchQuery, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetPatientResponseDto>>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }
    }
}