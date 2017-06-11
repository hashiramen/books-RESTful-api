using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using books.core.Domain;
using System.Linq;
using books.core.Repositories;

namespace books.infrastructure.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        public static ISet<Book> _books = new HashSet<Book>
        {
            new Book("Harry Potter", "J.K.Rowling", 2005, 842, "Fantasy"),
            new Book("Star Patrol", "Adam Konopnicki", 2015, 311, "Sci-Fi")
        };
        public async Task<Book> GetAsync(Guid Id)
            => await Task.FromResult(_books.SingleOrDefault(b => b.Id == Id));

        public async Task<Book> GetAsync(string title)
            => await Task.FromResult(_books.SingleOrDefault(b => b.Title == title));

        public async Task<IEnumerable<Book>> GetAllAsync()
            => await Task.FromResult(_books);

        public async Task AddAsync(Book book)
        {
            _books.Add(book);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid Id)
        {
            var book = await GetAsync(Id);
            _books.Remove(book);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Guid Id)
        {
            await Task.CompletedTask;
        }

    }
}