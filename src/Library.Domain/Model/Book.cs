using Library.Domain.Exceptions;
using Library.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Model
{
    public class Book : Entity
    {
        public string ISBN { get; private set; }

        public string Name { get; private set; }

        public string Genre { get; private set; }

        public string Description {  get; private set; }

        public string Author { get; private set; }

        public DateTime BorrowingTime { get; private set; }

        public DateTime ReturningTime { get; private set; }

#pragma warning disable CS8618 
        protected Book() { }
#pragma warning restore CS8618 

        public Book(string iSBN, string name, string genre, string description, string author, DateTime borrowingTime, DateTime returningTime)
        {

            ISBN = iSBN;

            Name = name;

            Genre = genre;

            Description = description;

            Author = author;

            BorrowingTime = borrowingTime;

            ReturningTime = returningTime;
        }

    }
}
