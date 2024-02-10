using AutoMapper;
using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Commands.CreateBookCommand
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request);

            var result = await _bookRepository.AddAsync(book);

            return result;
        }
    }
}
