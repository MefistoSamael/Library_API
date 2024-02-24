using Library.Application.Common.Models;
using MediatR;

namespace Library.Application.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommand : IRequest<AuthorDTO>
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        public UpdateAuthorCommand(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
