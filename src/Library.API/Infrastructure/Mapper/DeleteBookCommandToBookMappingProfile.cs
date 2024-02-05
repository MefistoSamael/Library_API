using AutoMapper;
using Library.API.Application.Commands;
using Library.Domain.Model;

namespace Library.API.Infrastructure.Mapper
{
    public class DeleteBookCommandToBookMappingProfile : Profile
    {
        public DeleteBookCommandToBookMappingProfile()
        {
            CreateMap<DeleteBookCommand, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
