using AutoMapper;
using Library.Application.Books.Commands.UpdateBookCommand;
using Library.Domain.Models.BookModel;

namespace Library.Application.Common.Mapper.BookCommandsToBook
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
