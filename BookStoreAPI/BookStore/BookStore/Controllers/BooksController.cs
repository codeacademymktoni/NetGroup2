using BookStore.DtoModels;
using BookStore.Mappings;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public IActionResult Get(string title, string author)
        {
            var books = _booksService.GetWithFilters(title, author);

            return Ok(books.Select(x => x.ToDtoModel()));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _booksService.GetById(id);
            return Ok(book.ToDtoModel());
        }

        [HttpPost]
        public IActionResult Create(BookDto book)
        {
            if (ModelState.IsValid)
            {
                var status = _booksService.Create(book.ToDomainModel());
                if (status)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("", "Book with same title already exists");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _booksService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(BookDto book)
        {
            if (ModelState.IsValid)
            {
                _booksService.Update(book.ToDomainModel());
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
