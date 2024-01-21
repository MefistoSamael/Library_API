using AutoMapper;
using Library.API.Application.Queries;
using Library.Domain.Model;

namespace Library.API.Mapper
{
    public class DtoToBookMappingProfile : Profile
    {
        public DtoToBookMappingProfile()
        {
            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}