using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PizzaPlace.Pages.Dashboard
{
    [Authorize]
    public class MenuModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
