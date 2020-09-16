using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading;
using LIS.API.DataTransferObjects.Equipments.Request;
using LIS.API.DataTransferObjects.Equipments.Response;
using FluentValidation;
using LIS.Common.Extensions;
using LIS.ServiceContracts.ServiceObjects;
using LIS.ServiceContracts.Services;
using Microsoft.AspNetCore.Cors;

namespace LIS.API.Controllers
{
    [Route("api/v1/Equipments")]
    [EnableCors("AllowOrigin")]
    public sealed class EquipmentsController : ApiController
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentsController(
            IEquipmentService equipmentService,
            IMapper mapper) : base(mapper)
        {
            _equipmentService = equipmentService;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(EquipmentResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateEquipmentAsync(
            [FromBody] EquipmentRequestDto createEquipmentRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var equipmentServiceObject = Mapper.Map<EquipmentServiceObject>(createEquipmentRequestDto);
                var serviceResponse = await _equipmentService.CreateEquipmentAsync(equipmentServiceObject, token);
                return new CreatedResult(string.Empty, Mapper.Map<EquipmentResponseDto>(serviceResponse));
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }

        [HttpGet(Name ="GetAllEquipments")]
        public async Task<IActionResult> GetAll(CancellationToken token = default)
        {
            try
            {
                var serviceResponse = await _equipmentService.GetAll(token);
                return new OkObjectResult(Mapper.Map<IEnumerable<EquipmentResponseDto>>(serviceResponse));
            }
            catch (Exception ex)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{equipmentId}")]
        [ProducesResponseType(200, Type = typeof(EquipmentResponseDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateEquipmentAsync(
            [FromRoute] int equipmentId,
            [FromBody] EquipmentRequestDto updateEquipmentRequestDto,
            CancellationToken token = default)
        {
            try
            {
                var equipmentServiceObject = Mapper.Map<EquipmentServiceObject>(updateEquipmentRequestDto);
                equipmentServiceObject.Id = equipmentId;
                var serviceResponse = await _equipmentService.UpdateEquipmentAsync(equipmentServiceObject, token);
                return new OkObjectResult(Mapper.Map<EquipmentResponseDto>(serviceResponse));
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{equipmentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteEquipmentByIdAsync(
            [FromRoute] int equipmentId,
            CancellationToken token = default)
        {
            try
            {
                await _equipmentService.DeleteEquipmentByIdAsync(equipmentId, token);
                return new StatusCodeResult(204);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}