using System;
namespace books.core.Domain
{
    public class User
    {
        public Guid Id {get; protected set;}
        public string FullName{get;protected set;}
        public string Email{get;protected set;}
        public string Password{get;protected set;}
        public string Salt{get;protected set;}
    }
}