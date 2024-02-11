using AutoMapper;
using Library.API.Application.Common;
using Library.Domain.Models.AuthorModel;

namespace Library.API.Infrastructure.Mapper.AuthorToDTO
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
