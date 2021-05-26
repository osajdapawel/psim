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
            // jesli adm to wtedy sprawdź generalnie do ogaru
            bool isUserAdmin = HttpContext.User.IsInRole("Admin");
            // pobranie nazwy użytkwnika
                
            if(isUserAdmin || await _suborderService.CheckPermitionAsync(id, HttpContext.User.Identity.Name))
            {
                var suborder = await _suborderService.GetSuborderByIdAsync(id);
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
            if (await _suborderService.UpdateSuborderAsync(updateSuborderDTO) == true)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        [SwaggerOperation(Summary = "Delete an existing suborder")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _suborderService.DeleteSuborderAsync(id) == true)
                return NoContent();
            else
                return BadRequest();
        }

    }
}