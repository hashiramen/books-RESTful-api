using System;
using System.Threading.Tasks;
using books.core.Repositories;
using books.infrastructure.DTO;

namespace books.infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<BookDTO> GetAsync(string title)
        {
            var book = await _bookRepository.GetAsync(title);

            var bookDTO = new BookDTO(){ Id = book.Id, Title = book.Title, Author = book.Author, ReleaseYear = book.ReleaseYear, Pages = book.Pages, Category = book.Category};
            return bookDTO;
        }
    }
}