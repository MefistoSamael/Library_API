using AutoMapper;
using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book? entity = await _bookRepository.GetAsyncById(request.Id);

            if (entity is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            Book book = _mapper.Map<Book>(request);

            return await _bookRepository.UpdateAsync(book);
        }
    }
}
