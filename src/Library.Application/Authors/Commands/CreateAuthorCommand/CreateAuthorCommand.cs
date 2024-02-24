using Library.Application.Common.Models;
using MediatR;

namespace Library.Application.Authors.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<AuthorDTO>
    {
        public string Name { get; set; }

        public CreateAuthorCommand(string name)
        {
            Name = name;
        }
    }
}
