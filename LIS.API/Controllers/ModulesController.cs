using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Modules;
using LIS.API.DataTransferObjects.Modules.Request;
using LIS.API.DataTransferObjects.Modules.Response;
using LIS.Common.Exceptions;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    public sealed class ModulesController : ApiController
    {
        private readonly IModulesService _modulesService;

        private readonly IValidator<CreateModuleRequestDto> _addModuleRequestValidator;

        private readonly IValidator<UpdateModuleRequestDto> _updateModuleRequestValidator;

        public ModulesController(
            IModulesService modulesService,
            IValidator<CreateModuleRequestDto> addModuleRequestValidator,
            IValidator<UpdateModuleRequestDto> updateModuleRequestValidator,
            IMapper mapper) : base(mapper)
        {
            _modulesService = modulesService;
            _addModuleRequestValidator = addModuleRequestValidator;
            _updateModuleRequestValidator = updateModuleRequestValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateModuleResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateModuleAsync(
            [FromQuery] int organisationId,
            [FromBody] CreateModuleRequestDto createModuleRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _addModuleRequestValidator.ValidateAsync(createModuleRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var moduleServiceObject = Mapper.Map<ModuleServiceObject>(createModuleRequestDto);
                moduleServiceObject.OrganisationId = organisationId;
                var serviceResponse = await _modulesService.CreateModuleAsync(moduleServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreateModuleResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }

        }

        [HttpGet]
        [ProducesResponseType(201, Type = typeof(IEnumerable<GetModuleResponseDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllModulesByOrganisationIdAsync(
            [FromQuery] int organisationId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _modulesService.GetAllModulesByOrganisationId(organisationId, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetModuleResponseDto>>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPut("{moduleId}")]
        [ProducesResponseType(201, Type = typeof(UpdateModuleResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateModuleAsync(
            [FromQuery] int organisationId,
            [FromRoute] int moduleId,
            [FromBody] UpdateModuleRequestDto updateModuleRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updateModuleRequestValidator.ValidateAsync(updateModuleRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }
                var moduleServiceObject = Mapper.Map<ModuleServiceObject>(updateModuleRequestDto);
                moduleServiceObject.OrganisationId = organisationId;
                moduleServiceObject.Id = moduleId;
                var serviceResponse = await _modulesService.UpdateModuleAsync(moduleServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateModuleResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpPost]
        [Route("{moduleId}/pages")]
        [ProducesResponseType(201, Type = typeof(AddModulePageMappingResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPageToModuleAsync(
            [FromRoute] int moduleId,
            [FromBody] AddModulePageMappingRequestDto addModulePageMappingRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var modulePageMappingServiceObject = Mapper.Map<ModulePageMappingServiceObject>(addModulePageMappingRequestDto);
                modulePageMappingServiceObject.ModuleId = moduleId;
                await _modulesService.AddPageToModuleAsync(modulePageMappingServiceObject, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }

        }

        [HttpGet("{moduleId}/pages")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetPagesByModuleIdResponseDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllPagesByModuleIdAsync(
            [FromRoute] int moduleId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _modulesService.GetAllPagesByModuleIdAsync(moduleId, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetPagesByModuleIdResponseDto>>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}