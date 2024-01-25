using Library.API.Application.Queries;
using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Commands
{
    public class CreateBookCommand : IRequest<Book?>
    {
        public BookDTO Book { get; private set; }

        public CreateBookCommand(BookDTO book) 
        {  
            Book = book; 
        }


    }
}
