using AutoMapper;
using Library.API.Application.Books.Commands.UpdateBookCommand;
using Library.Domain.Models.AuthorModel;
using Library.Domain.Models.BookModel;

namespace Library.API.Infrastructure.Mapper.BookCommandsToBook
{
    public class UpdateBookCommandToBookMappingProfile : Profile
    {
        public UpdateBookCommandToBookMappingProfile()
        {
            CreateMap<UpdateBookCommand, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
