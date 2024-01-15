using Library.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Model
{
    public class Book
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

            if (borrowingTime == DateTime.MaxValue)
            {
                throw new ArgumentException("Borrowing time are not valid");
            }
            else
            {
                BorrowingTime = borrowingTime;
            }
            if (returningTime == DateTime.MaxValue)
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
    }
}
