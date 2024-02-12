using AutoMapper;
using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book? entity = await _bookRepository.GetAsyncById(request.Id);

            if (entity is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            await _bookRepository.DeleteAsync(entity);
        }
    }
}
