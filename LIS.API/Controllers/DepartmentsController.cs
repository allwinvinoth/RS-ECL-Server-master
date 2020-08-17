using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading;
using LIS.API.DataTransferObjects.Departments.Request;
using LIS.API.DataTransferObjects.Departments.Response;
using FluentValidation;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    public sealed class DepartmentsController : ApiController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IValidator<CreateDepartmentRequestDto> _createDepartmentRequestDtoValidator;
        private readonly IValidator<UpdateDepartmentRequestDto> _updateDepartmentRequestDtoValidator;

        public DepartmentsController(
            IDepartmentService departmentService,
            IValidator<CreateDepartmentRequestDto> createDepartmentRequestDto,
            IValidator<UpdateDepartmentRequestDto> updateDepartmentRequestDto,
            IMapper mapper) : base(mapper)
        {
            _departmentService = departmentService;
            _createDepartmentRequestDtoValidator = createDepartmentRequestDto;
            _updateDepartmentRequestDtoValidator = updateDepartmentRequestDto;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateDepartmentResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateDepartmentAsync(
            [FromQuery] int branchId,
            [FromBody] CreateDepartmentRequestDto createDepartmentRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _createDepartmentRequestDtoValidator.ValidateAsync(createDepartmentRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                var departmentServiceObject = Mapper.Map<DepartmentServiceObject>(createDepartmentRequestDto);
                departmentServiceObject.BranchId = branchId;
                var serviceResponse = await _departmentService.CreateDepartmentAsync(departmentServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreateDepartmentResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetDepartmentResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDepartmentsByBranchIdAsync(
            [FromQuery] int branchId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _departmentService.GetDepartmentsByBranchIdAsync(branchId, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetDepartmentResponseDto>>(serviceResponse));
            }
            catch (Exception)
            {
                return new NotFoundResult(); 
            }
        }

        [HttpPut("{departmentId}")]
        [ProducesResponseType(200, Type = typeof(UpdateDepartmentResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateDepartmentAsync(
            [FromQuery] int branchId,
            [FromRoute] int departmentId,
            [FromBody] UpdateDepartmentRequestDto updateDepartmentRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updateDepartmentRequestDtoValidator.ValidateAsync(updateDepartmentRequestDto, token);
                if (!validationResult.IsValid)
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                var departmentServiceObject = Mapper.Map<DepartmentServiceObject>(updateDepartmentRequestDto);
                departmentServiceObject.BranchId =branchId;
                departmentServiceObject.Id = departmentId;
                var serviceResponse = await _departmentService.UpdateDepartmentAsync(departmentServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateDepartmentResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{departmentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteDepartmentByIdAsync(
            [FromRoute] int departmentId,
            CancellationToken token = default)
        {
            try
            {
                await _departmentService.DeleteDepartmentByIdAsync(departmentId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}