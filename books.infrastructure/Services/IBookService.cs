using System;
using System.Threading.Tasks;
using books.infrastructure.DTO;

namespace books.infrastructure.Services
{
    public interface IBookService
    {
        Task<BookDTO> GetAsync(string title);
    }
}