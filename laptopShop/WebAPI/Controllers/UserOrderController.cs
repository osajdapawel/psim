using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderController : ControllerBase
    {
        private readonly IUserOrderService _userOrderService;

        public UserOrderController(IUserOrderService userOrderService)
        {
            _userOrderService = userOrderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var userName = HttpContext.User.Identity.Name;

            return Ok(await _userOrderService.GetAllAsync(userName));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var userName = HttpContext.User.Identity.Name;

            return Ok(await _userOrderService.GetByIdAsync(id));
        }

    }
}
