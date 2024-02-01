using Library.API.Application.Queries;
using Library.API.Models;
using Library.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Application.Commands
{
    public class DeleteBookCommand : IRequest<Book>
    {
        public BookDTO Book { get; private set; }

        public DeleteBookCommand(BookDTO book) {  Book = book; }

    }
}
