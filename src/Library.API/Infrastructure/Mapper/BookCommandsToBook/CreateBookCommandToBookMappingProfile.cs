using AutoMapper;
using Library.API.Application.Books.Commands.CreateBookCommand;
using Library.Domain.Models.BookModel;

namespace Library.API.Infrastructure.Mapper.BookCommandsToBook
{
    public class CreateBookCommandToBookMappingProfile : Profile
    {
        public CreateBookCommandToBookMappingProfile()
        {
            CreateMap<CreateBookCommand, Book>();
        }
    }
}
