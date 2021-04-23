using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages.Admin
{
    public class OrdersListModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrdersListModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<OrdersListViewModel> OrdersList { get; set; }

        public void OnGet()
        {
            var orders = _orderService.GetAll();

            OrdersList = orders.Select(x => x.ToOrderListViewModel()).ToList();
        }

        public IActionResult OnGetSetProcessed(int id)
        {
            _orderService.SetProcessed(id);
            return RedirectToPage();
        }
    }
}
