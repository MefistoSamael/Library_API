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

        protected Book() { }

        public Book(string iSBN, string name, string genre, string description, string author, DateTime borrowingTime, DateTime returningTime)
        {
            ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Author = author ?? throw new ArgumentNullException(nameof(author));

            if (borrowingTime == DateTime.MinValue)
            {
                throw new ArgumentException("Borrowing time are not valid");
            }
            else
            {
                BorrowingTime = borrowingTime;
            }

            if (returningTime == DateTime.MinValue)
            {
                throw new ArgumentException("Returning time are not valid");
            }
            else
            {
                ReturningTime = returningTime;
            }

            if (borrowingTime > returningTime)
            {
                throw new LibraryDomainException("Time when book was borrowed, are later then returning time");
            }
        }

        public void UpdateISBN(string iSBN)
        {
            ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
        }

        public void UpdateName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(Name));
        }

        public void UpdateGenre(string genre)
        {
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
        }

        public void UpdateDesctiption(string description) 
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public void UpdateAuthor(string author)
        {
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }

        public void UpdateBorrowingTime(DateTime borrowingTime)
        {
            if (borrowingTime == DateTime.MinValue)
            {
                throw new ArgumentException("Borrowing time are not valid");
            }
            else if (borrowingTime > ReturningTime)
            {
                throw new LibraryDomainException("Time when book was borrowed, are later then returning time");
            }
            else
            {
                BorrowingTime = borrowingTime;
            }
        }

        public void UpdateReturningTime(DateTime returningTime)
        {
            if (returningTime == DateTime.MinValue)
            {
                throw new ArgumentException("Returning time are not valid");
            }
            else if (BorrowingTime > returningTime)
            {
                throw new LibraryDomainException("Time when book was borrowed, are later then returning time");
            }
            else
            {
                ReturningTime = returningTime;
            }
        }
    }
}
