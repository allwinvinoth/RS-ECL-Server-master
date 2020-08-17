using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LIS.ServiceContracts.Services;
using FluentValidation;
using LIS.API.DataTransferObjects.Gender.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using LIS.Common.Exceptions;
using LIS.Common.Extensions;
using LIS.API.DataTransferObjects.Gender.Response;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public sealed class GenderController : ApiController
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<AddGenderRequestDto> _addGenderRequestValidator;
        private readonly IValidator<UpdateGenderRequestDto> _updateGenderRequestValidator;
        public GenderController(
            IGenderService genderService,
            IValidator<AddGenderRequestDto> addGenderRequestValidator,
            IValidator<UpdateGenderRequestDto> updateGenderRequestValidator,
        IMapper mapper) : base(mapper)
        {
            _genderService = genderService;
            _addGenderRequestValidator = addGenderRequestValidator;
            _updateGenderRequestValidator = updateGenderRequestValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AddGenderResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateGenderAsync(
            [FromBody] AddGenderRequestDto addGenderRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _addGenderRequestValidator.ValidateAsync(addGenderRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }
                var genderServiceObject = Mapper.Map<GenderServiceObject>(addGenderRequestDto);
                var serviceResult = await _genderService.CreateGenderAsync(genderServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<AddGenderResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpGet("{genderId}")]
        [ProducesResponseType(200, Type = typeof(GetGenderResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetGenderByIdAsync(
            [FromRoute] int genderId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _genderService.GetGenderByIdAsync(genderId, token);
                return new OkObjectResult(Mapper.Map<GetGenderResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetGenderResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetGenderListAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _genderService.GetGenderListAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetGenderResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpPut("{genderId}")]
        [ProducesResponseType(200, Type = typeof(UpdateGenderResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateGenderByIdAsync(
            [FromRoute] int genderId,
            [FromBody] UpdateGenderRequestDto updateGenderRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updateGenderRequestValidator.ValidateAsync(updateGenderRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var genderServiceObject = Mapper.Map<GenderServiceObject>(updateGenderRequestDto);
                genderServiceObject.Id = genderId;
                var serviceResult = await _genderService.UpdateGenderByIdAsync(genderServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateGenderResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{genderId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteGenderByIdAsync(
            [FromRoute] int genderId,
            CancellationToken token = default)
        {
            try
            {
                await _genderService.DeleteGenderByIdAsync(genderId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}