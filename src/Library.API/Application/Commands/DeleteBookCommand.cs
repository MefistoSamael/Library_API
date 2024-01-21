using Library.API.Application.Queries;
using MediatR;

namespace Library.API.Application.Commands
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public BookDTO Book { get; private set; }

        public DeleteBookCommand(BookDTO book) {  Book = book; }

    }
}
