using Library.Domain.Models.BookModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.CommandRepositories
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

        public async Task<Book?> GetByIdAsync(int bookId)
        {
            var book = await _context.Books.AsNoTracking().SingleOrDefaultAsync(b => b.Id == bookId);
            if (book is not null)
            {
                book.Author = _context.Authors.AsNoTracking().Where(a => a.Id == bookId).Single();
            }

            return book;
        }

        public async Task<Book?> GetByISBNAsync(string ISBN)
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
