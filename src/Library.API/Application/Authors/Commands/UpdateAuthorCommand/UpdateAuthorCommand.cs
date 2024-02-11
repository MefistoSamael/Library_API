using Library.API.Application.Common;
using Library.Domain.Models.AuthorModel;
using MediatR;

namespace Library.API.Application.Authors.Commands.UpdateAuthorCommand
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
