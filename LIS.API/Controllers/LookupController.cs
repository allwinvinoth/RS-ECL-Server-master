using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading;
using LIS.API.DataTransferObjects.Lookup;
using FluentValidation;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using Microsoft.AspNetCore.Cors;
using LIS.API.DataTransferObjects.Lookup.Response;

namespace LIS.API.Controllers
{
    [Route("api/v1/Lookup")]
    [EnableCors("AllowOrigin")]
    public sealed class LookupController : ApiController
    {
        private readonly ILookupService _lookupService;

        public LookupController(
            ILookupService lookupService,
            IMapper mapper) : base(mapper)
        {
            _lookupService = lookupService;
        }


        //[Route("api/v1/Lookup/{param}")]
        [HttpGet("{param}")]
        public async Task<IActionResult> GetAllLookupValues( [FromRoute] string param,
            CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _lookupService.GetAll(param, token);
                return new OkObjectResult(Mapper.Map<IEnumerable<LookupResponseDto>>(serviceResponse));
            }
            catch (Exception ex)
            {
                return new NotFoundResult();
            }
        }
    }
}