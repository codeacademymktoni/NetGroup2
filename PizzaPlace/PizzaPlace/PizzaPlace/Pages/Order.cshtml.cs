using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public OrderViewModel Order { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var newOrder = Order.ToDomainModel();
            _orderService.Create(newOrder);
        }
    }
}
