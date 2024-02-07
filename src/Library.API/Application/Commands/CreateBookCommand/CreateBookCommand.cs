﻿using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Commands.CreateBookCommand
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string ISBN { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime BorrowingTime { get; set; }

        public DateTime ReturningTime { get; set; }


        public CreateBookCommand(string isbn, string name, string genre, string description, string author, DateTime borrowingTime, DateTime returningTime)
        {
            ISBN = isbn;
            Name = name;
            Genre = genre;
            Description = description;
            Author = author;
            BorrowingTime = borrowingTime;
            ReturningTime = returningTime;
        }
    }
}