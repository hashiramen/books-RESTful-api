using Microsoft.AspNetCore.Mvc;
using books.infrastructure.Services;
using System.Threading.Tasks;
using books.infrastructure.Commands.Books;

namespace books.api.Controllers
{
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("{title}")]
        public async Task<IActionResult> Get(string title)
        {
            var book = await _bookService.GetAsync(title);
            if(book == null)
            {
                return NotFound();
            }

            return Json(book);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(string title)
        {
            var book = await _bookService.GetAllAsync();
            if(book == null)
            {
                return NotFound();
            }

            return Json(book);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post([FromBody]CreateBook request)
        {
           await _bookService.AddAsync(request.Title, request.Author, request.ReleaseYear, request.Pages, request.Category);
           
           return Created($"books/{request.Title}", new object());
        }
    }
}