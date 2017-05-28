using System;
using System.Collections.Generic;

namespace books.core.Domain
{
    public class Shelf
    {
        public Guid Id{get; protected set;}
        public User User{get;protected set;}
        public IEnumerable<Book> Books{get; protected set;}
    }
}