using Library.API.Application.Queries;
using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public BookDTO Book { get; private set; }

        public UpdateBookCommand(BookDTO book) {  Book = book; }
    }
}
