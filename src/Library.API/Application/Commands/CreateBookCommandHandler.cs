using AutoMapper;
using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book?>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Book?> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
                Book book = _mapper.Map<Book>(request.Book);

                var result = _bookRepository.Add(book);

                

                if (await _bookRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
                    return result;
                else
                    return null;

        }
    }
}
