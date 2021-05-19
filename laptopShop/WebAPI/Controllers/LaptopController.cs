using Application.DTO;
using Application.Interfaces;
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
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopService _laptopService;

        public LaptopController(ILaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves all laptops")]
        public async Task<IActionResult> Get()
        {
            var laptops = await _laptopService.GetAllLaptopsAsync();
            return Ok(laptops);
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves laptop with specific id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var laptop = await _laptopService.GetLaptopByIdAsync(id);

            if (laptop == null)
                return NotFound();

            return Ok(laptop);
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Create a new laptop")]
        public async Task<IActionResult> Post(CreateLaptopDTO createLaptopDTO)
        {
            var laptop = await _laptopService.AddNewLaptopAsync(createLaptopDTO);

            return Created($"api/laptops/{laptop.Id}", laptop);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update laptop")]
        public async Task<IActionResult> Put(UpdateLaptopDTO updateLaptop)
        {
            if (await _laptopService.UpdateLaptopAsync(updateLaptop) == true)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete an existing laptop")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _laptopService.DeleteLaptopAsync(id) == true)
                return NoContent();
            else
                return BadRequest();
        }

    }
}
// dla swaggera koniecznym jest okreslenie typu metody HTTP, bo inaczej rzuca błędem