using Library.Domain.Models.AuthorModel;
using Library.Domain.SeedWork;

namespace Library.Domain.Models.BookModel
{
    public class Book : Entity
    {
        public string ISBN { get; private set; }

        public string Name { get; private set; }

        public string Genre { get; private set; }

        public string Description { get; private set; }

        public Author Author { get; private set; }

        public int AuthorId { get; private set; }

        public DateTime BorrowingTime { get; private set; }

        public DateTime ReturningTime { get; private set; }

#pragma warning disable CS8618 
        protected Book() { }
#pragma warning restore CS8618 

        public Book(string iSBN, string name, string genre, string description, int AuthorId, DateTime borrowingTime, DateTime returningTime)
        {

            ISBN = iSBN;

            Name = name;

            Genre = genre;

            Description = description;

            this.AuthorId = AuthorId;

            BorrowingTime = borrowingTime;

            ReturningTime = returningTime;
        }

    }
}
