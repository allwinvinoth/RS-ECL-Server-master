using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading;
using LIS.API.DataTransferObjects.TestMaster;
using FluentValidation;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using Microsoft.AspNetCore.Cors;

namespace LIS.API.Controllers
{
    [Route("api/v1/IndividualTestMaster")]
    [EnableCors("AllowOrigin")]
    public sealed class IndividualTestMasterController : ApiController
    {
        private readonly IIndividualTestMasterService _individualTestMasterService;

        public IndividualTestMasterController(
            IIndividualTestMasterService individualTestMasterService,
            IMapper mapper) : base(mapper)
        {
            _individualTestMasterService = individualTestMasterService;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(IndividualTestResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateIndividualTestMasterAsync(
            [FromBody] IndividualTestResponseDto createIndividualTestMasterRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var individualTestMasterServiceObject = Mapper.Map<IndividualTestServiceObject>(createIndividualTestMasterRequestDto);
                var serviceResponse = await _individualTestMasterService.CreateIndividualTestMasterAsync(individualTestMasterServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<IndividualTestResponseDto>(serviceResponse));
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet(Name ="GetAllIndividualTestMasters")]
        public async Task<IActionResult> GetAllIndividualTestMasters(CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _individualTestMasterService.GetAll(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<IndividualTestResponseDto>>(serviceResponse));
            }
            catch (Exception ex)
            {
                return new NotFoundResult();
            }      
        }

        [HttpPut("{individualTestMasterId}")]
        [ProducesResponseType(200, Type = typeof(IndividualTestResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateIndividualTestMasterAsync(
            [FromRoute] int individualTestMasterId,
            [FromBody] IndividualTestResponseDto updateIndividualTestMasterRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var individualTestMasterServiceObject = Mapper.Map<IndividualTestServiceObject>(updateIndividualTestMasterRequestDto);
                ///individualTestMasterServiceObject.Id = individualTestMasterId;
                var serviceResponse = await _individualTestMasterService.UpdateIndividualTestMasterAsync(individualTestMasterServiceObject, token);
                return new OkObjectResult(Mapper.Map<IndividualTestResponseDto>(serviceResponse));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{individualTestMasterId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteIndividualTestMasterByIdAsync(
            [FromRoute] int individualTestMasterId,
            CancellationToken token = default)
        {
            try
            {
                await _individualTestMasterService.DeleteIndividualTestMasterByIdAsync(individualTestMasterId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}