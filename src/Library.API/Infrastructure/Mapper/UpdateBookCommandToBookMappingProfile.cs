using AutoMapper;
using Library.API.Application.Commands;
using Library.Domain.Model;

namespace Library.API.Infrastructure.Mapper
{
    public class UpdateBookCommandToBookMappingProfile : Profile
    {
        public UpdateBookCommandToBookMappingProfile()
        {
            CreateMap<UpdateBookCommand, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)); ;
        }
    }
}
