using Microsoft.AspNetCore.Mvc;
using books.infrastructure.Services;
using System.Threading.Tasks;

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

    }
}