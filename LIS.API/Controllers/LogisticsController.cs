using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LIS.API.DataTransferObjects.Logistics.Request;
using LIS.API.DataTransferObjects.Logistics.Response;
using LIS.Common.Exceptions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace LIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LogisticsController : ApiController
    {
        private readonly ILogisticService _logisticService;

        public LogisticsController(ILogisticService logisticService,
            IMapper mapper) : base(mapper)
        {
            _logisticService = logisticService;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateLogisticResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateLogisticAsync([FromBody] CreateLogisticRequestDto createLogisticRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var logisticServiceObject = this.Mapper.Map<LogisticAndServiceObject>(createLogisticRequestDto);
                var serviceResponse = await _logisticService.CreateLogisticAsync(logisticServiceObject, token);
                return new CreatedResult(string.Empty, this.Mapper.Map<CreateLogisticResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpPut("{logisticId}")]
        [ProducesResponseType(200, Type = typeof(UpdateLogisticResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateLogisticByIdAsync(
            [FromRoute] int logisticId,
            [FromBody] UpdateLogisticRequestDto updateLogisticRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var logisticServiceObject = this.Mapper.Map<LogisticAndServiceObject>(updateLogisticRequestDto);
                logisticServiceObject.Id = logisticId;
                var serviceResponse = await _logisticService.UpdateLogisticByIdAsync(logisticServiceObject, token);
                return new OkObjectResult(this.Mapper.Map<UpdateLogisticResponseDto>(serviceResponse));
            }
            catch (BadRequestException e)
            {
                return new BadRequestObjectResult(e.Error);
            }
        }

        [HttpDelete("{logisticId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteLogisticByIdAsync(
            [FromRoute] int logisticId,
            CancellationToken token = default)
        {
            try
            {
                await _logisticService.DeleteLogisticByIdAsync(logisticId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetLogisticResponseDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllLogisticsAsync(
           CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _logisticService.GetAllLogisticsAsync(token);
                return new OkObjectResult(this.Mapper.Map<IEnumerable<GetLogisticResponseDto>>(serviceResult));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{logisticId}")]
        [ProducesResponseType(200, Type = typeof(GetLogisticResponseDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLogisticByIdAsync(
            [FromRoute] int logisticId,
            CancellationToken token = default)
        {
            try
            {
                var serviceResult = await _logisticService.GetLogisticByIdAsync(logisticId, token);
                return new OkObjectResult(this.Mapper.Map<GetLogisticResponseDto>(serviceResult));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}