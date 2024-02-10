using MediatR;

namespace Library.API.Application.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
