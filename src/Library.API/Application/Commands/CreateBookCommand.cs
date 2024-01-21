using Library.API.Application.Queries;
using MediatR;

namespace Library.API.Application.Commands
{
    public class CreateBookCommand : IRequest<bool>
    {
        public BookDTO Book { get; private set; }

        public CreateBookCommand(BookDTO book) 
        {  
            Book = book; 
        }


    }
}
