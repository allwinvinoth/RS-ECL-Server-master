using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Categories.Request;
using LIS.API.DataTransferObjects.Categories.Response;
using LIS.Common.Exceptions;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace LIS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public sealed class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<AddCategoryRequestDto> _addCategoryRequestValidator;
        private readonly IValidator<UpdateCategoryRequestDto> _updateCategoryRequestValidator;
        public CategoriesController(
            ICategoryService categoryService,
            IValidator<AddCategoryRequestDto> addCategoryRequestValidator,
            IValidator<UpdateCategoryRequestDto> updateCategoryRequestValidator,
        IMapper mapper) : base(mapper)
        {
            _categoryService = categoryService;
            _addCategoryRequestValidator = addCategoryRequestValidator;
            _updateCategoryRequestValidator = updateCategoryRequestValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AddCategoryResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCategoryAsync(
            [FromBody] AddCategoryRequestDto addCategoryRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _addCategoryRequestValidator.ValidateAsync(addCategoryRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }
                var categoryServiceObject = Mapper.Map<CategoryServiceObject>(addCategoryRequestDto);
                var serviceResult = await _categoryService.CreateCategoryAsync(categoryServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<AddCategoryResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(GetCategoryResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryByIdAsync(
            [FromRoute] long categoryId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _categoryService.GetCategoryByIdAsync(categoryId, token);
                return new OkObjectResult(Mapper.Map<GetCategoryResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetCategoryResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoriesAsync(
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _categoryService.GetCategoriesAsync(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<GetCategoryResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(UpdateCategoryResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCategoryByIdAsync(
            [FromRoute] int categoryId,
            [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updateCategoryRequestValidator.ValidateAsync(updateCategoryRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var categoryServiceObject = Mapper.Map<CategoryServiceObject>(updateCategoryRequestDto);
                categoryServiceObject.Id = categoryId;
                var serviceResult = await _categoryService.UpdateCategoryByIdAsync(categoryServiceObject, token);
                return new OkObjectResult(Mapper.Map<UpdateCategoryResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCategoryByIdAsync(
            [FromRoute] long categoryId,
            CancellationToken token = default)
        {
            try
            {
                await _categoryService.DeleteCategoryByIdAsync(categoryId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}