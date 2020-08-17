using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Branches.Request;
using LIS.API.DataTransferObjects.Branches.Response;
using LIS.Common.Exceptions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using LIS.Common.Extensions;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    public sealed class BranchesController : ApiController
    {
        private readonly IBranchService _branchService;
        private readonly IValidator<CreateBranchRequestDto> _createBranchRequestDtoValidator;
        private readonly IValidator<UpdateBranchRequestDto> _updateBranchRequestDtoValidator;

        public BranchesController(
            IBranchService branchService, 
            IValidator<CreateBranchRequestDto> createBranchRequestDto,
            IValidator<UpdateBranchRequestDto> updateBranchRequestDtoValidator,
            IMapper mapper): base(mapper)
        {
            _branchService = branchService;
            _createBranchRequestDtoValidator = createBranchRequestDto;
            _updateBranchRequestDtoValidator=updateBranchRequestDtoValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateBranchResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateBranchAsync(
            [FromQuery] int organisationId, 
            [FromBody] CreateBranchRequestDto createBranchRequestDto, 
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _createBranchRequestDtoValidator.ValidateAsync(createBranchRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                var branchServiceObject = Mapper.Map<BranchServiceObject>(createBranchRequestDto);
                branchServiceObject.OrganisationId = organisationId;
                var serviceResponse = await _branchService.CreateBranchAsync(branchServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreateBranchResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetBranchResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBranchesByOrganisationIdAsync(
            [FromQuery] int organisationId, 
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _branchService.GetBranchesByOrganisationIdAsync(organisationId, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetBranchResponseDto>>(serviceResponse));
            }
            catch (Exception)
            {
                return new NotFoundResult(); ;
            }
        }

        [HttpPut("{branchId}")]
        [ProducesResponseType(200, Type = typeof(UpdateBranchResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateBranchAsync(
            [FromQuery] int organisationId, 
            [FromRoute] int branchId, 
            [FromBody] UpdateBranchRequestDto updateBranchRequestDto, 
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updateBranchRequestDtoValidator.ValidateAsync(updateBranchRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                var branchServiceObject = Mapper.Map<BranchServiceObject>(updateBranchRequestDto);
                branchServiceObject.OrganisationId = organisationId;
                branchServiceObject.Id = branchId;
                var serviceResponse = await _branchService.UpdateBranchAsync(branchServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<UpdateBranchResponseDto>(serviceResponse));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpDelete("{branchId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteBranchByIdAsync(
            [FromRoute] int branchId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _branchService.DeleteBranchByIdAsync(branchId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}