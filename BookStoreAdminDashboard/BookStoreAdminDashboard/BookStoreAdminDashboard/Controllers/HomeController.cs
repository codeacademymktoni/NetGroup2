using BookStoreAdminDashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreAdminDashboard.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(string successMessage)
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync("https://localhost:44308/api/books");

            if (httpResponse.IsSuccessStatusCode) 
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                var books = JsonConvert.DeserializeObject<List<BookViewModel>>(response);

                ViewBag.SuccessMessage = successMessage;
                return View(books);
            }

            return View("Error");
        }

        public async Task<IActionResult> Details(int id)
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync($"https://localhost:44308/api/books/{id}");

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                var book = JsonConvert.DeserializeObject<BookViewModel>(response);

                return View(book);
            }

            return View("Error");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.DeleteAsync($"https://localhost:44308/api/books/{id}");

            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(HomeController.Index), new { SuccessMessage = "Book deleted"});
            }

            return View("Error");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.PostAsJsonAsync($"https://localhost:44308/api/books", viewModel);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Index), new { SuccessMessage = "Book created successfully" });
                }

                return View("Error");
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync($"https://localhost:44308/api/books/{id}");

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                var book = JsonConvert.DeserializeObject<BookViewModel>(response);

                return View(book);
            }

            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.PutAsJsonAsync($"https://localhost:44308/api/books", viewModel);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Index), new { SuccessMessage = "Book updated successfully" });
                }

                return View("Error");
            }
            else
            {
                return View(viewModel);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
