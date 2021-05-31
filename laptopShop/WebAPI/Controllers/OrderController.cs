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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("all")]
        //[Route("all")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Retrieves all orders")]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // można tak zmodyfikować metodę confirm purchase aby zwróciła podzamówienia które nie mogą zostać zrealizowane, bez potwierdzania innych
        // następnie będzie można je zmodyfikować i dopiero ponownie wywołać tę metodę w celu potwierdzenia
        [HttpGet("buy/{id}")]
        [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Confirm purchase of items in suborders related with order with specific id. Retrieves not realised suborders due to lack of laptops")]
        public async Task<IActionResult> Buy(Guid id)
        {
            bool userHasPermition = await _orderService.CheckPermitionAsync(id, HttpContext.User.Identity.Name);

            if (userHasPermition)
            {
                //wywołaj metodę
                var notRealisedSuborders = await _orderService.ConfirmPurchaseAsync(id);
                if (notRealisedSuborders.Count() == 0)
                    return NoContent();
                else
                    return Ok(notRealisedSuborders);
            }
            else
                return NotFound();
            
        }


        //  to nie działa, a te podwójne na dole działają
        [HttpGet("user/{id}")]
        //[Route("getAll/{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Retrieves all orders that belongs to user with specific id")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var orders = await _orderService.GetAllUserOrdersByUserIdAsync(id);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        [SwaggerOperation(Summary = "Retrieves order with specific id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            bool isUserAdmin = HttpContext.User.IsInRole("Admin");

            if (isUserAdmin || await _orderService.CheckPermitionAsync(id, HttpContext.User.Identity.Name))
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order != null)
                    return Ok(order);

            }
            return NotFound();
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Retrieves all orders that belong to currently logged user")]
        public async Task<IActionResult> GetAllByUserName()
        {
            var orders = await _orderService.GetAllUserOrdersByUserNameAsync(HttpContext.User.Identity.Name);
            return Ok(orders);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [SwaggerOperation(Summary = "Create a new order")]
        public async Task<IActionResult> Post(CreateOrderDTO createOrderDTO)
        {
            var order = await _orderService.AddNewOrderAsync(createOrderDTO);

            return Created($"api/orders/{order.Id}", order);
        }

        [HttpPut]
        [Authorize(Roles = "Admin, User")]
        [SwaggerOperation(Summary = "Update order")]
        public async Task<IActionResult> Put(UpdateOrderDTO updateOrderDTO)
        {
            bool isUserAdmin = HttpContext.User.IsInRole("Admin");

            // Do edycji prawo ma tylko i wyłącznie "właściciel" podzamowienia lub admin 
            // sprawdzenie czy user jest adminem lub właścicielem
            if (isUserAdmin || await _orderService.CheckPermitionAsync(updateOrderDTO.Id, HttpContext.User.Identity.Name))
                if (await _orderService.UpdateOrderAsync(updateOrderDTO) == true)
                    return NoContent();

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        [SwaggerOperation(Summary = "Delete an existing order")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isUserAdmin = HttpContext.User.IsInRole("Admin");

            if (isUserAdmin || await _orderService.CheckPermitionAsync(id, HttpContext.User.Identity.Name))
                if (await _orderService.DeleteOrderAsync(id) == true)
                    return NoContent();

            return BadRequest();
        }
    }
}
