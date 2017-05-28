using System;

namespace books.core.Domain
{
    public class Book
    {
        public Guid Id{get; protected set;}
        public string Title { get; protected set; }
        public string Author{get;protected set;}
        public int ReleaseYear{get;protected set;}
        public int Pages{get;protected set;}
        public string Category{get;protected set;}
        public DateTime UpdatedAt{get;protected set;}

        public Book(string title, string author, int releaseYear, int pages, string category)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
            Pages = pages;
            Category = category;
        }
    }
}