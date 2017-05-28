using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using books.core.Domain;

namespace books.core.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetAsync(Guid Id);
        Task<Book> GetAsync(string title);
        Task AddAsync(Book book);
        Task UpdateAsync(Guid Id);
        Task RemoveAsync(Guid Id);
    }
}