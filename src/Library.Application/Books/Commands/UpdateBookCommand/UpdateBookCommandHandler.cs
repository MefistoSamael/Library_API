using AutoMapper;
using Library.Application.Common.Models;
using Library.Domain.Models.AuthorModel;
using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.Application.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDTO>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        private readonly IAuthorRepository _authorRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<BookDTO> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book? entity = await _bookRepository.GetAsyncById(request.Id);

            if (entity is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            Author? author = await _authorRepository.GetAsyncById(request.AuthorId);

            if (author is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            Book book = _mapper.Map<Book>(request);

            Book result = await _bookRepository.UpdateAsync(book);

            return _mapper.Map<BookDTO>(result);
        }
    }
}
