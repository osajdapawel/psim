using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves all deliveries")]
        public async Task<IActionResult> Get()
        {
            var deliveries = await _deliveryService.GetAllDeliveriesAsync();
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves deliveries with specific id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var delivery = await _deliveryService.GetDeliveryByIdAsync(id);

            if (delivery == null)
                return NotFound();
            else
                return Ok(delivery);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Create a new delivery")]
        public async Task<IActionResult> Post(CreateDeliveryDTO createDelivery)
        {
            var delivery = await _deliveryService.AddNewDeliveryAsync(createDelivery);

            return Created($"api/delivery/{delivery.Id}", delivery);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Update a delivery")]
        public async Task<IActionResult> Put(DeliveryDTO newDelivery)
        {
            if (await _deliveryService.UpdateSuborderAsync(newDelivery))
                return NoContent();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Delete an existing delivery")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _deliveryService.DeleteDeliveryAsync(id))
                return NoContent();
            else
                return BadRequest();
        }

    }
}
