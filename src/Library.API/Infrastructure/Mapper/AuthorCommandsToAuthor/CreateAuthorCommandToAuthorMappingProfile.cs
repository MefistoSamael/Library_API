using AutoMapper;
using Library.API.Application.Authors.Commands.CreateAuthorCommand;
using Library.Domain.Models.AuthorModel;

namespace Library.API.Infrastructure.Mapper.AuthorCommandsToAuthor
{
    public class CreateAuthorCommandToAuthorMappingProfile : Profile
    {
        public CreateAuthorCommandToAuthorMappingProfile() 
        {
            CreateMap<CreateAuthorCommand, Author>();
        }
    }
}
