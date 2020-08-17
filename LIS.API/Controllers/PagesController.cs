using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Pages.Request;
using LIS.API.DataTransferObjects.Pages.Response;
using LIS.Common.Exceptions;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    public sealed class PagesController : ApiController
    {
        private readonly IPagesService _pagesService;

        private readonly IValidator<CreatePageRequestDto> _addPageRequestValidator;

        private readonly IValidator<UpdatePageRequestDto> _updatePageRequestValidator;

        public PagesController(
            IPagesService pagesService,
            IValidator<CreatePageRequestDto> addPageRequestValidator,
            IValidator<UpdatePageRequestDto> updatePageRequestValidator,
            IMapper mapper) : base(mapper)
        {
            _pagesService = pagesService;
            _addPageRequestValidator = addPageRequestValidator;
            _updatePageRequestValidator = updatePageRequestValidator;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreatePageResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreatePageAsync(
            [FromQuery] int organisationId,
            [FromBody] CreatePageRequestDto createPageRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _addPageRequestValidator.ValidateAsync(createPageRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var pageServiceObject = Mapper.Map<PageServiceObject>(createPageRequestDto);
                pageServiceObject.OrganisationId = organisationId;
                var serviceResult = await _pagesService.CreatePageAsync(pageServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<CreatePageResponseDto>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpGet]
        [ProducesResponseType(201, Type = typeof(GetPageResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllPagesForOrganisationAsync(
            [FromQuery] int organisationId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _pagesService.GetAllPagesForOrganisationAsync(organisationId, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<CreatePageResponseDto>>(serviceResult));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(201, Type = typeof(UpdatePageResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdatePageAsync(
            [FromQuery] int organisationId,
            [FromQuery] int pageId, [FromBody] UpdatePageRequestDto updatePageRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var validationResult = await _updatePageRequestValidator.ValidateAsync(updatePageRequestDto, token);
                if (!validationResult.IsValid)
                {
                    return new BadRequestObjectResult(validationResult.Errors.ToValidationErrors());
                }

                var pageServiceObject = Mapper.Map<PageServiceObject>(updatePageRequestDto);
                pageServiceObject.OrganisationId = organisationId;
                pageServiceObject.Id = pageId;
                var serviceResponse = await _pagesService.UpdatePageAsync(pageServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<UpdatePageResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }
    }
}