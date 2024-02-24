using MediatR;

namespace Library.Application.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
