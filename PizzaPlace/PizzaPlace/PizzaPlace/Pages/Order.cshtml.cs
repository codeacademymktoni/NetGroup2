using System;
using System.ComponentModel.DataAnnotations;
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
        private readonly ISubscriptionService subscriptionService;

        public OrderModel(IOrderService orderService, ISubscriptionService subscriptionService)
        {
            _orderService = orderService;
            this.subscriptionService = subscriptionService;
        }

        [BindProperty]
        public OrderViewModel Order { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var newOrder = Order.ToDomainModel();
                _orderService.Create(newOrder);

                return RedirectToPage("ConfirmationPage", "OrderCompleted");
            }

            return Page();
        }

        public IActionResult OnPostSubscribe(string email)
        {
            subscriptionService.Create(email);

            return RedirectToPage("ConfirmationPage", "SubscriptionCompleted");
        }
    }
}
