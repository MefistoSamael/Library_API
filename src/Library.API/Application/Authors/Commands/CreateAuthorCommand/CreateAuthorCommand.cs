using Library.API.Application.Common;
using Library.Domain.Models.AuthorModel;
using MediatR;

namespace Library.API.Application.Authors.Commands.CreateAuthorCommand
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
