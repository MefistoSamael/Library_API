using Library.API.Application.Queries;
using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
#pragma warning disable CS8618
        public int Id { get; set; }
        public string ISBN { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime BorrowingTime { get; set; }

        public DateTime ReturningTime { get; set; }
#pragma warning restore CS8618

        public UpdateBookCommand(int id, string isbn, string name, string genre, string description, string author, DateTime borrowingTime, DateTime returningTime)
        {
            Id = id;
            ISBN = isbn;
            Name = name;
            Genre = genre;
            Description = description;
            Author = author;
            BorrowingTime = borrowingTime;
            ReturningTime = returningTime;
        }

    }
}
