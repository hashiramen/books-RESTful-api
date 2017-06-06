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

namespace books.tests.endtoend.Controllers
{
    public class BooksControllerTest : ControllerTestsBase
    {
        [Fact]
        public async Task given_valid_book_name_book_should_exist()
        {
            var bookName = "Gwiezdny Patrol";

            var response = await Client.GetAsync($"books/{bookName}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public void given_test_is_equal_true()
        {
            Assert.Equal(2, 1 + 1);
        }

        private async Task<BookDTO> GetBookAsync(string title)
        {
            var response = await Client.GetAsync($"books/{title}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BookDTO>(responseString);
        }
    }
}