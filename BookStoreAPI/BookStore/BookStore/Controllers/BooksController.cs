using BookStore.DtoModels;
using BookStore.Mappings;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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


        /// <summary>
        ///  Returns all books for given parameters, if any
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string title, string author)
        {
            var user = User;
            var books = _booksService.GetWithFilters(title, author);

            return Ok(books.Select(x => x.ToDtoModel()));
        }


        /// <summary>
        /// Returns books for given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _booksService.GetById(id);
            return Ok(book.ToDtoModel());
        }

        /// <summary>
        /// Creates new book from given data
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(BookDto book)
        {
            var user = User;
            if (ModelState.IsValid)
            {
                var status = await _booksService.CreateAsync(book.ToDomainModel());

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


        /// <summary>
        /// Deletes book for given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _booksService.Delete(id);
            return Ok();
        }


        /// <summary>
        /// Updated given book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <response code="200">No data</response>
        /// <response code="400">If request data is invalid</response>         
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
