using System;

namespace books.infrastructure.DTO
{
    public class BookDTO
    {
        public Guid Id{get; set;}
        public string Title { get; set; }
        public string Author{get;set;}
        public int ReleaseYear{get;set;}
        public int Pages{get; set;}
        public string Category{get; set;}       
    }
}