using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Models;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages.Admin
{
    [Authorize(Roles = "Admin, Cook, Delivery" )]
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

        public void OnGetPending()
        {
            var orders = _orderService.GetByStatus(OrderStatus.Pending);
            OrdersList = orders.Select(x => x.ToOrderListViewModel()).ToList();
        }

        public void OnGetProcessed()
        {
            var orders = _orderService.GetByStatus(OrderStatus.Processed);
            OrdersList = orders.Select(x => x.ToOrderListViewModel()).ToList();
        }

        public void OnGetDone()
        {
            var orders = _orderService.GetByStatus(OrderStatus.Done);
            OrdersList = orders.Select(x => x.ToOrderListViewModel()).ToList();
        }

        public IActionResult OnGetSetProcessed(int id)
        {
            _orderService.SetStatus(id, OrderStatus.Processed);
            return RedirectToPage("OrdersList", "Pending");
        }

        public IActionResult OnGetSetDone(int id)
        {
            _orderService.SetStatus(id, OrderStatus.Done);
            return RedirectToPage("OrdersList", "Processed");
        }
    }
}
