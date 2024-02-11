using AutoMapper;
using Library.API.Application.Authors.Commands.UpdateAuthorCommand;
using Library.Domain.Models.AuthorModel;

namespace Library.API.Infrastructure.Mapper.AuthorCommandsToAuthor
{
    public class UpdateAuthorCommandToAuthorMappingProfile : Profile
    {
        public UpdateAuthorCommandToAuthorMappingProfile() 
        {
            CreateMap<UpdateAuthorCommand, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(command => command.Id));
        }
    }
}
