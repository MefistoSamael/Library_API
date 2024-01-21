using Library.API.Application.Queries;
using MediatR;

namespace Library.API.Application.Commands
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public BookDTO Book { get; private set; }

        public UpdateBookCommand(BookDTO book) {  Book = book; }
    }
}
