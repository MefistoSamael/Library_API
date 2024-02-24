using AutoMapper;
using Library.Application.Common.Models;
using Library.Domain.Models.BookModel;

namespace Library.Application.Common.Mapper.EntityToDTO
{
    public class BookToDTOMappingProfile : Profile
    {
        public BookToDTOMappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
