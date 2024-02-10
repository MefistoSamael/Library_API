using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Commands.CreateBookCommand
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string ISBN { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }

        public DateTime BorrowingTime { get; set; }

        public DateTime ReturningTime { get; set; }


        public CreateBookCommand(string isbn, string name, string genre, string description, int authorId, DateTime borrowingTime, DateTime returningTime)
        {
            ISBN = isbn;
            Name = name;
            Genre = genre;
            Description = description;
            AuthorId = authorId;
            BorrowingTime = borrowingTime;
            ReturningTime = returningTime;
        }
    }
}
