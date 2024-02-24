using MediatR;

namespace Library.Application.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
