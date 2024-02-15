using AutoMapper;
using Library.API.Application.Common;
using Library.Domain.Models.AuthorModel;
using Library.Domain.Models.BookModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace Library.API.Infrastructure.Mapper.EntityToDTO
{
    public class BookToDTOMappingProfile : Profile
    {
        public BookToDTOMappingProfile() 
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src =>src.AuthorId))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
