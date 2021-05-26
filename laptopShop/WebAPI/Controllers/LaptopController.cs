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
        //[Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Create a new laptop")]
        public async Task<IActionResult> Post(CreateLaptopDTO createLaptopDTO)
        {
            var laptop = await _laptopService.AddNewLaptopAsync(createLaptopDTO);

            return Created($"api/laptop/{laptop.Id}", laptop);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Update laptop")]
        public async Task<IActionResult> Put(UpdateLaptopDTO updateLaptop)
        {
            if (await _laptopService.UpdateLaptopAsync(updateLaptop) == true)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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

// https://stackoverflow.com/questions/3297048/403-forbidden-vs-401-unauthorized-http-responses
/*
 
    In summary, 
    a 401 Unauthorized response should be used for missing or bad authentication, 
    and a 403 Forbidden response should be used afterwards, 
    when the user is authenticated but isn’t authorized 
    to perform the requested operation on the given resource. 

 */