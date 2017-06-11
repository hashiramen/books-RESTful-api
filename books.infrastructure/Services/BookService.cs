using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using books.core.Domain;
using books.core.Repositories;
using books.infrastructure.DTO;

namespace books.infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(string title, string author, int releaseYear, int pages, string category)
        {
            var book = await _bookRepository.GetAsync(title);
            if(book != null)
            {
                throw new Exception($"Book with title: '{title}', already exists");
            }

            book = new Book(title, author, releaseYear, pages, category);
            await _bookRepository.AddAsync(book);
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDTO> GetAsync(string title)
        {
            var book = await _bookRepository.GetAsync(title);

            return _mapper.Map<Book, BookDTO>(book);
        }
    }
}