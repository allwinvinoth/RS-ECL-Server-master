using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Organisations.Request;
using LIS.API.DataTransferObjects.Organisations.Response;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using LIS.Common.Extensions;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class OrganisationsController : ApiController
    {
        private readonly IOrganisationService _organisationService;
        private readonly IValidator<CreateOrganisationRequestDto> _createOrganisationRequestDtoValidator;
        private readonly IValidator<UpdateOrganisationRequestDto> _updateOrganisationRequestDtoValidator;

        public OrganisationsController(
            IOrganisationService organisationService, 
            IValidator<CreateOrganisationRequestDto> createOrganisationRequestDto,
            IValidator<UpdateOrganisationRequestDto> updateOrganisationRequestDtoValidator,
            IMapper mapper):base(mapper)
        {
            _organisationService = organisationService;
            _createOrganisationRequestDtoValidator = createOrganisationRequestDto;
            _updateOrganisationRequestDtoValidator = updateOrganisationRequestDtoValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateOrganisationResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddOrganisationAsync(
            [FromBody] CreateOrganisationRequestDto createOrganisationRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _createOrganisationRequestDtoValidator.ValidateAsync(createOrganisationRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                var organisationServiceObject = Mapper.Map<OrganisationServiceObject>(createOrganisationRequestDto);
                var serviceResponse = await _organisationService.AddOrganisationAsync(organisationServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreateOrganisationResponseDto>(serviceResponse));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetOrganisationResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetOrganisations(
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _organisationService.GetOrganisationsAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetOrganisationResponseDto>>(serviceResponse));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpGet("{organisationId}")]
        [ProducesResponseType(200, Type = typeof(GetOrganisationResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetOrganisationById(
            [FromRoute] int organisationId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _organisationService.GetOrganisationByIdAsync(organisationId, token);
                return new OkObjectResult(Mapper.Map<GetOrganisationResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{organisationId}")]
        [ProducesResponseType(200, Type = typeof(UpdateOrganisationResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateOrganisationByIdAsync(
            [FromRoute] int organisationId, 
            [FromBody] UpdateOrganisationRequestDto updateOrganisationRequestDto, 
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updateOrganisationRequestDtoValidator.ValidateAsync(updateOrganisationRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                var organisationServiceObject = Mapper.Map<OrganisationServiceObject>(updateOrganisationRequestDto);
                organisationServiceObject.Id = organisationId;
                var serviceResponse = await _organisationService.UpdateOrganisationByIdAsync(organisationServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<UpdateOrganisationResponseDto>(serviceResponse));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }

        [HttpDelete("{organisationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteOrganisationByIdAsync(
            [FromRoute] int organisationId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _organisationService.DeleteOrganisationByIdAsync(organisationId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}