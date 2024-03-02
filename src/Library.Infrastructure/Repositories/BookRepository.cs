using Library.Domain.Models.BookModel;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Authors.Where(a => a.Id == book.AuthorId).Load();

            var result = _context.Books.Add(book).Entity;
            
            await _context.SaveChangesAsync();

            return result;

        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            
            await _context.SaveChangesAsync();
        }

        public async Task<Book?> GetAsyncById(int bookId)
        {
            var book = await _context.Books.AsNoTracking().SingleOrDefaultAsync(b => b.Id == bookId);
            if (book is not null)
            {
                book.Author = _context.Authors.AsNoTracking().Where(a => a.Id == bookId).Single();
            }

            return book;
        }

        public async Task<Book?> GetAsyncByISBN(string ISBN)
        {
            var book = await _context.Books.AsNoTracking().SingleOrDefaultAsync(b => b.ISBN == ISBN);
            if (book is not null)
            {
                book.Author = _context.Authors.AsNoTracking().Where(a => a.Id == book.Id).Single();
            }

            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _context.Authors.Where(a => a.Id == book.AuthorId).Load();

            var result = _context.Update(book).Entity;

            await _context.SaveChangesAsync();

            return result;

        }

        public async Task<IEnumerable<Book>> GetPaginatedBooksAsync(int pageNumber, int pageSize)
        {
            return await _context.Books
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Include(b => b.Author).ToListAsync();
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
