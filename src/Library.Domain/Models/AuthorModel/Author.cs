using Library.Domain.Models.BookModel;
using Library.Domain.SeedWork;

namespace Library.Domain.Models.AuthorModel
{
    public class Author : Entity
    {
        public string Name { get; private set; }

        public List<Book> Books { get; private set; }

#pragma warning disable CS8618 
        protected Author() 
        {
            Books = new List<Book>();
        }
#pragma warning restore CS8618 

        public Author(string name) 
        {
            Name = name;
            Books = new List<Book>();
        }
    }
}