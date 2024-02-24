using AutoMapper;
using Library.Application.Common.Models;
using Library.Domain.Models.AuthorModel;

namespace Library.Application.Common.Mapper.EntityToDTO
{
    public class AuthorToDTOMappingProfile : Profile
    {
        public AuthorToDTOMappingProfile()
        {
            CreateMap<Author, AuthorDTO>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
