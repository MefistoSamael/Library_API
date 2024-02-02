using Library.API.Application.Queries;
using Library.API.Models;
using Library.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Application.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteBookCommand(int id) 
        {
            Id = id;
        }
    }
}
