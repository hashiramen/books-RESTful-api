using System.Net.Http;
using System.Threading.Tasks;
using books.api;
using books.infrastructure.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;
using FluentAssertions;
using System.Net;
using Moq;
using books.infrastructure.Commands.Books;

namespace books.tests.endtoend.Controllers
{
    public class BooksControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task get_list_of_all_books()
        {
            var response = await Client.GetAsync("books");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task given_valid_book_name_book_should_exist()
        {
            var bookName = "Harry Potter";

            var response = await Client.GetAsync($"books/{bookName}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task given_json_object_should_add_new_book()
        {
            var command = new CreateBook
            {
                Title = "Game of Thrones: A Song of Ice and Fire",
                Author = "George R. R. Martin",
                Pages = 694, 
                ReleaseYear = 1996,
                Category = "Fantasy"
            };

            var payload = GetPayload(command);
            var response = await Client.PostAsync("books/add", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"books/{command.Title}");

            var book = await GetBookAsync(command.Title);
            book.Title.ShouldBeEquivalentTo(command.Title);
        }

        private async Task<BookDTO> GetBookAsync(string title)
        {
            var response = await Client.GetAsync($"books/{title}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BookDTO>(responseString);
        }
    }
}