using AutoMapper;
using Library.API.Models;
using Library.Domain.Exceptions;
using Library.Domain.Model;
using Library.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Application.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Book?>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Book?> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request.Book);

            var result = _bookRepository.Delete(book);


            if (await _bookRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
                return result;
            else
                return null;

        }
    }
}
