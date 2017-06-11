using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using books.infrastructure.DTO;

namespace books.infrastructure.Services
{
    public interface IBookService
    {
        Task<BookDTO> GetAsync(string title);
        Task<IEnumerable<BookDTO>> GetAllAsync();
        Task AddAsync(string title, string author, int releaseYear, int pages, string category);
    }
}