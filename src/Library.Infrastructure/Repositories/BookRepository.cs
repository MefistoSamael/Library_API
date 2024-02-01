using Library.Domain.Model;
using Library.Domain.SeedWork;
using Library.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Book Add(Book book)
        {
            var result = _context.Books.Add(book).Entity;
            
            _context.SaveChanges();

            return result;

        }

        public Book Delete(Book book)
        {
            var result = _context.Books.Remove(book).Entity;
            
            _context.SaveChanges();
            
            return result;
        }

        public async Task<Book?> GetAsyncById(int bookId)
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<Book?> GetAsyncByISBN(string ISBN)
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.ISBN == ISBN);
        }

        public Book Update(Book book)
        {
            _context.Update(book);

            _context.SaveChanges();

            return book;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
