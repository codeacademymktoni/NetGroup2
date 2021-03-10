using Microsoft.AspNetCore.Mvc;

namespace MyRecipes.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult ErrorNotFound()
        {
            return View();
        }
    }
}
