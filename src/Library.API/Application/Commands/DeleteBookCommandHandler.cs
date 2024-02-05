using AutoMapper;
using Library.API.Models;
using Library.Domain.Exceptions;
using Library.Domain.Model;
using Library.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Application.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book? entity = await _bookRepository.GetAsyncById(request.Id);
            if (entity is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            Book book = _mapper.Map<Book>(request);

            await _bookRepository.DeleteAsync(book);
        }
    }
}
