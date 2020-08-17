using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.Common.Exceptions;
using LIS.ServiceContracts.Services;
using LIS.API.DataTransferObjects.HomeCollection.Request;
using LIS.API.DataTransferObjects.HomeCollection.Response;
using Microsoft.AspNetCore.Mvc;
using LIS.ServiceContracts.ServiceObjects;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeCollectionController : ApiController
    {
        private readonly IHomeCollectionService _homeCollectionService;
        public HomeCollectionController(IHomeCollectionService homeCollectionService,
            IMapper mapper) : base(mapper)
        {
            _homeCollectionService = homeCollectionService;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateHomeCollectionResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateHomeCollectionAsync([FromBody] CreateHomeCollectionRequestDto createHomeCollectionRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var homeCollectionServiceObject = this.Mapper.Map<HomeCollectionServiceObject>(createHomeCollectionRequestDto);
                var serviceResponse = await _homeCollectionService.CreateHomeCollectionAsync(homeCollectionServiceObject, token);
                return new CreatedResult(string.Empty, this.Mapper.Map<CreateHomeCollectionResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpPut("{homeCollectionId}")]
        [ProducesResponseType(200, Type = typeof(UpdateHomeCollectionResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateHomeCollectionByIdAsync(
            [FromRoute] int homeCollectionId,
            [FromBody] UpdateHomeCollectionRequestDto updateHomeCollectionRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var homeCollectionServiceObject = this.Mapper.Map<HomeCollectionServiceObject>(updateHomeCollectionRequestDto);
                homeCollectionServiceObject.Id = homeCollectionId;
                var serviceResponse = await _homeCollectionService.UpdateHomeCollectionByIdAsync(homeCollectionServiceObject, token);
                return new OkObjectResult(this.Mapper.Map<UpdateHomeCollectionResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpDelete("{homeCollectionId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteHomeCollectionByIdAsync(
            [FromRoute] int homeCollectionId,
            CancellationToken token = default)
        {
            try
            {
                await _homeCollectionService.DeleteHomeCollectionByIdAsync(homeCollectionId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetHomeCollectionResponseDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllHomeCollectionsAsync(
           CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _homeCollectionService.GetAllHomeCollectionsAsync(token);
                return new OkObjectResult(this.Mapper.Map<IEnumerable<GetHomeCollectionResponseDto>>(serviceResult));
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{homeCollectionId}")]
        [ProducesResponseType(200, Type = typeof(GetHomeCollectionResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetHomeCollectionByIdAsync(
            [FromRoute] int homeCollectionId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _homeCollectionService.GetHomeCollectionByIdAsync(homeCollectionId, token);
                return new OkObjectResult(this.Mapper.Map<GetHomeCollectionResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}