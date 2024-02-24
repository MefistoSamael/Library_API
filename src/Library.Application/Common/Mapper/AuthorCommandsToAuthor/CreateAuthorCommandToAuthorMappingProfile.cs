using AutoMapper;
using Library.Application.Authors.Commands.CreateAuthorCommand;
using Library.Domain.Models.AuthorModel;

namespace Library.Application.Common.Mapper.AuthorCommandsToAuthor
{
    public class CreateAuthorCommandToAuthorMappingProfile : Profile
    {
        public CreateAuthorCommandToAuthorMappingProfile()
        {
            CreateMap<CreateAuthorCommand, Author>();
        }
    }
}
