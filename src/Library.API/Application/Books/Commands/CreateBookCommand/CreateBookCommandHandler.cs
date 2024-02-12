using AutoMapper;
using Library.API.Application.Common;
using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Commands.CreateBookCommand
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDTO>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request);

            var result = await _bookRepository.AddAsync(book);

            return _mapper.Map<BookDTO>(result);
        }
    }
}
