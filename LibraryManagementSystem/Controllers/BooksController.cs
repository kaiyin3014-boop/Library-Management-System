using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("GetBookById/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("GetBookByTitle/{title}")]
        public async Task<ActionResult<Book>> GetBookByTitle(string title)
        {
            var book = await _bookService.GetBookByTitleAsync(title);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            var success = await _bookService.UpdateBookAsync(book);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("AddBook")]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            var createdBook = await _bookService.CreateBookAsync(book);
            return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var success = await _bookService.DeleteBookAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
