using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get()
        {
            var laptops = await _laptopService.GetAllLaptopsAsync();
            return Ok(laptops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var laptop = await _laptopService.GetLaptopByIdAsync(id);
            
            if (laptop == null)
                return NotFound();
            
            return Ok(laptop);
        }

    }
}
// dla swaggera koniecznym jest okreslenie typu metody HTTP, bo inaczej rzuca błędem