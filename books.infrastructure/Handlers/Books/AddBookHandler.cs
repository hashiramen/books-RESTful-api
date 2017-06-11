using System;
using System.Threading.Tasks;
using books.infrastructure.Commands;
using books.infrastructure.Commands.Books;
using books.infrastructure.Services;

namespace books.infrastructure.Handlers.Books
{
    public class AddBookHandler : ICommandHandler<CreateBook>
    {
        private readonly IBookService _bookService;
        public AddBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task HandleAsync(CreateBook command)
        {
            await _bookService.AddAsync(command.Title, command.Author, command.ReleaseYear, command.Pages, command.Category);
        }
    }
}