using AutoMapper;
using LIS.API.DataTransferObjects.ContainerTypes.Request;
using LIS.ServiceContracts.Services;
using LIS.Common.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using LIS.ServiceContracts.ServiceObjects;
using LIS.API.DataTransferObjects.ContainerTypes.Response;
using System;
using System.Collections.Generic;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContainerTypesController : ApiController
    {
        private readonly IContainerTypeService _containerTypeService;
        private readonly IValidator<CreateContainerTypeRequestDto> _createContainerTypeRequestDtoValidator;

        public ContainerTypesController(IContainerTypeService containerTypeService,
            IValidator<CreateContainerTypeRequestDto> createContainerTypeRequestDtoValidator,
            IMapper mapper) : base(mapper)
        {
            _containerTypeService = containerTypeService;
            _createContainerTypeRequestDtoValidator = createContainerTypeRequestDtoValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateContainerTypeRequestDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateContainerTypeAsync([FromBody] CreateContainerTypeRequestDto createContainerTypeRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _createContainerTypeRequestDtoValidator.ValidateAsync(createContainerTypeRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());

                var containerTypeServiceObject = Mapper.Map<ContainerTypeServiceObject>(createContainerTypeRequestDto);
                var serviceResponse = await _containerTypeService.CreateContainerTypeAsync(containerTypeServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreateContainerTypeResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetContainerTypeResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetContainerTypesAsync(CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _containerTypeService.GetContainerTypesAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetContainerTypeResponseDto>>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{containerTypeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteContainerTypeByIdAsync(
            [FromRoute] int containerTypeId,
            CancellationToken token = default)
        {
            try
            {
                await _containerTypeService.DeleteContainerTypeByIdAsync(containerTypeId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}