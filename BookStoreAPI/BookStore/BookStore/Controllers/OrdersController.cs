using BookStore.DtoModels;
using BookStore.Mappings;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDto createOrderDto)
        {
            if (ModelState.IsValid)
            {
                _ordersService.Create(createOrderDto.ToDomainModel());
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
