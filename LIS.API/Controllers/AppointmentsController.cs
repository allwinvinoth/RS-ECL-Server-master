using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Appointments.Request;
using LIS.API.DataTransferObjects.Appointments.Response;
using LIS.Common.Exceptions;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    public sealed class AppointmentsController : ApiController
    {
        private readonly IValidator<CreateAppointmentRequestDto> _createAppointmentRequestDtoValidator;

        private readonly IAppointmentsService _appointmentService;

        public AppointmentsController(
            IAppointmentsService appointmentsService,
            IValidator<CreateAppointmentRequestDto> createAppointmentRequestDtoValidator,
            IMapper mapper) : base(mapper)
        {
            _appointmentService = appointmentsService;
            _createAppointmentRequestDtoValidator = createAppointmentRequestDtoValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateAppointmentResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAppointmentAsync(
            [FromBody] CreateAppointmentRequestDto createAppointmentRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _createAppointmentRequestDtoValidator.ValidateAsync(createAppointmentRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var appointmentServiceObject = Mapper.Map<AppointmentServiceObject>(createAppointmentRequestDto);
                var serviceResponse = await _appointmentService.CreateAppointmentAsync(appointmentServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreateAppointmentResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SearchAppointmentsResponseDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SearchAppointmentsAsync(
            [FromQuery] string searchQuery,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _appointmentService.SearchAppointmentAsync(searchQuery, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<SearchAppointmentsResponseDto>>(serviceResponse));
            }
            catch (Exception e)
            {
                return new NotFoundResult();
            }
        }
    }
}