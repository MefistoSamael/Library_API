using AutoMapper;
using Library.API.Application.Books.Commands.DeleteBookCommand;
using Library.Domain.Models.BookModel;

namespace Library.API.Infrastructure.Mapper.BookCommandsToBook
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
