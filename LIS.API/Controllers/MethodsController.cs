using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading;
using LIS.API.DataTransferObjects.Methods.Request;
using LIS.API.DataTransferObjects.Methods.Response;
using FluentValidation;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using Microsoft.AspNetCore.Cors;

namespace LIS.API.Controllers
{
    [Route("api/v1/Methods")]
    [EnableCors("AllowOrigin")]
    public sealed class MethodsController : ApiController
    {
        private readonly IMethodService _methodService;
        //private readonly IValidator<CreateMethodRequestDto> _createMethodRequestDtoValidator;
        //private readonly IValidator<UpdateMethodRequestDto> _updateMethodRequestDtoValidator;

        public MethodsController(
            IMethodService methodService,
            //IValidator<CreateMethodRequestDto> createMethodRequestDto,
            //IValidator<UpdateMethodRequestDto> updateMethodRequestDto,
            IMapper mapper) : base(mapper)
        {
            _methodService = methodService;
            //_createMethodRequestDtoValidator = createMethodRequestDto;
            //_updateMethodRequestDtoValidator = updateMethodRequestDto;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateMethodResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMethodAsync(
            [FromBody] CreateMethodRequestDto createMethodRequestDto,
            CancellationToken token = default)
        {
            try
            {
                //var validationResult = await _createMethodRequestDtoValidator.ValidateAsync(createMethodRequestDto, token);
                //if (!validationResult.IsValid)
                //return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                var methodServiceObject = Mapper.Map<MethodServiceObject>(createMethodRequestDto);
                var serviceResponse = await _methodService.CreateMethodAsync(methodServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreateMethodResponseDto>(serviceResponse));
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }

        //[HttpGet(Name ="GetById")]
        //[ProducesResponseType(200, Type = typeof(GetMethodResponseDto))]
        //[ProducesResponseType(404)]
        //public async Task<IActionResult> GetMethodsByBranchIdAsync(
        //    [FromQuery] int branchId,
        //    CancellationToken token = default)
        //{
        //    try
        //    {
        //        var serviceResponse = await _methodService.GetMethodsByBranchIdAsync(branchId, token);
        //        return new OkObjectResult(Mapper.Map<IEnumerable<GetMethodResponseDto>>(serviceResponse));
        //    }
        //    catch (Exception ex)
        //    {
        //        return new NotFoundResult(); 
        //    }
        //}

        [HttpGet(Name ="GetAllMethods")]
        public async Task<IActionResult> GetAll(CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _methodService.GetAll(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetMethodResponseDto>>(serviceResponse));
            }
            catch (Exception ex)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{methodId}")]
        [ProducesResponseType(200, Type = typeof(UpdateMethodResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateMethodAsync(
            [FromQuery] int departmentId,
            [FromRoute] int methodId,
            [FromBody] UpdateMethodRequestDto updateMethodRequestDto,
            CancellationToken token = default)
        {
            try
            {
                //var validationResult = await _updateMethodRequestDtoValidator.ValidateAsync(updateMethodRequestDto, token);
                //if (!validationResult.IsValid)
                //    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                var methodServiceObject = Mapper.Map<MethodServiceObject>(updateMethodRequestDto);
                methodServiceObject.id = methodId;
                var serviceResponse = await _methodService.UpdateMethodAsync(methodServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateMethodResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{methodId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteMethodByIdAsync(
            [FromRoute] int methodId,
            CancellationToken token = default)
        {
            try
            {
                await _methodService.DeleteMethodByIdAsync(methodId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}