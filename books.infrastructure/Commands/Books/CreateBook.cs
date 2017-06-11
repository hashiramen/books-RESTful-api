using books.infrastructure.Commands;

namespace books.infrastructure.Commands.Books
{
    public class CreateBook : ICommand
    {   
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public int Pages { get; set; } 
        public string Category { get; set; }
    }
}