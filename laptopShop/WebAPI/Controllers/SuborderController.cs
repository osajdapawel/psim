using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class SuborderController : ControllerBase
    {
        private readonly ISuborderService _suborderService;

        public SuborderController(ISuborderService suborderService)
        {
            _suborderService = suborderService;
        }

        // Prawdopodobnie konieczne będzie zrobienie policy based authorization
        // tutaj mimo iż admin jest uprawniony to nie będzie właścicielem i nie otrzyma pliku
        // można sprawdzić czy dany user to nie admin, ale to chyba droga na skróty
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        [SwaggerOperation(Summary = "Retrieves suborder with specific id")]
        public async Task<IActionResult> Get(Guid id)
        {
            bool isUserAdmin = HttpContext.User.IsInRole("Admin");
                
            // jeśli user jest adminem to  dalej nie sprawdzaj czy jest "właścicieliem" podzamówienia
            if(isUserAdmin || await _suborderService.CheckPermitionAsync(id, HttpContext.User.Identity.Name))
            {
                var suborder = await _suborderService.GetSuborderByIdAsync(id);
                if(suborder != null)
                    return Ok(suborder);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [SwaggerOperation(Summary = "Create a new suborder")]
        public async Task<IActionResult> Post(CreateSuborderDTO createSuborderDTO)
        {
            var suborder = await _suborderService.AddNewSuborderAsync(createSuborderDTO);

            return Created( $"api/suborders/{suborder.Id}", suborder);
        }

        [HttpPut]
        [Authorize(Roles = "Admin, User")]
        [SwaggerOperation(Summary = "Update suborder")]
        public async Task<IActionResult> Put(UpdateSuborderDTO updateSuborderDTO)
        {
            bool isUserAdmin = HttpContext.User.IsInRole("Admin");

            // Do edycji prawo ma tylko i wyłącznie "właściciel" podzamowienia lub admin 
            // sprawdzenie czy user jest adminem lub właścicielem
            if (isUserAdmin || await _suborderService.CheckPermitionAsync(updateSuborderDTO.Id, HttpContext.User.Identity.Name))
                if (await _suborderService.UpdateSuborderAsync(updateSuborderDTO) == true) 
                    return NoContent();
            
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        [SwaggerOperation(Summary = "Delete an existing suborder")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isUserAdmin = HttpContext.User.IsInRole("Admin");

            if (isUserAdmin || await _suborderService.CheckPermitionAsync(id, HttpContext.User.Identity.Name))
                if (await _suborderService.DeleteSuborderAsync(id) == true)
                    return NoContent();
           
            return BadRequest();
        }

    }
}

// co robi celnik w terminalu
// CLI 