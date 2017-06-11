using Microsoft.AspNetCore.Mvc;
using books.infrastructure.Services;
using System.Threading.Tasks;
using books.infrastructure.Commands.Books;
using books.infrastructure.Commands;

namespace books.api.Controllers
{
    [Route("[controller]")]
    public class BooksController : ApiControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
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
        public async Task<IActionResult> Post([FromBody]CreateBook command)
        {
           await CommandDispatcher.DispatchAsync(command);

           return Created($"books/{command.Title}", new object());
        }
    }
}