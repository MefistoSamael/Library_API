using AutoMapper;
using Library.API.Application.Common;
using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDTO>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book? entity = await _bookRepository.GetAsyncById(request.Id);

            if (entity is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            Book book = _mapper.Map<Book>(request);

            Book result = await _bookRepository.UpdateAsync(book);

            return _mapper.Map<BookDTO>(result);
        }
    }
}
