using AutoMapper;
using Library.Application.Books.Commands.CreateBookCommand;
using Library.Domain.Models.BookModel;

namespace Library.Application.Common.Mapper.BookCommandsToBook
{
    public class CreateBookCommandToBookMappingProfile : Profile
    {
        public CreateBookCommandToBookMappingProfile()
        {
            CreateMap<CreateBookCommand, Book>();
        }
    }
}
