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

            ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            if (ISBN.Length != 10 && ISBN.Length != 13)
                throw new LibraryDomainException("ISBN length are invalid");

            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (Name.Length == 0)
                throw new LibraryDomainException("Name length are invalid");

            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            if (Genre.Length == 0)
                throw new LibraryDomainException("Genre length are invalid");

            Description = description ?? throw new ArgumentNullException(nameof(description));
            if (Description.Length == 0)
                throw new LibraryDomainException("Description length are invalid");

            Author = author ?? throw new ArgumentNullException(nameof(author));
            if (Author.Length == 0)
                throw new LibraryDomainException("Author length are invalid");


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

        public void UpdateBook(Book newBook)
        {

            ISBN = newBook.ISBN ?? throw new ArgumentNullException(nameof(ISBN));

            Name = newBook.Name ?? throw new ArgumentNullException(nameof(Name));

            Genre = newBook.Genre ?? throw new ArgumentNullException(nameof(Genre));

            Description = newBook.Description ?? throw new ArgumentNullException(nameof(Description));

            Author = newBook.Author ?? throw new ArgumentNullException(nameof(Author));

            if (newBook.BorrowingTime == DateTime.MinValue)
            {
                throw new ArgumentException("Borrowing time are not valid");
            }
            else if (newBook.BorrowingTime > ReturningTime)
            {
                throw new LibraryDomainException("Time when book was borrowed, are later then returning time");
            }
            else
            {
                BorrowingTime = newBook.BorrowingTime;
            }

            if (newBook.ReturningTime == DateTime.MinValue)
            {
                throw new ArgumentException("Returning time are not valid");
            }
            else if (BorrowingTime > newBook.ReturningTime)
            {
                throw new LibraryDomainException("Time when book was borrowed, are later then returning time");
            }
            else
            {
                ReturningTime = newBook.ReturningTime;
            }
            
        }
    }
}
