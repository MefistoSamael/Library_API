using Azure.Core;
using Library.Domain.Models.AuthorModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository, IDisposable
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Author> AddAsync(Author author)
        {
            var result = (await _context.Authors.AddAsync(author)).Entity;

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task DeleteAsync(Author author)
        {
            _context.Authors.Remove(author);

            await _context.SaveChangesAsync();
        }

        public Task<Author?> GetAsyncById(int authorId)
        {
            return _context.Authors.AsNoTracking().Where(a => a.Id == authorId).Include(a => a.Books).FirstOrDefaultAsync();
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _context.Books.Where(b => b.AuthorId == author.Id).Load();

            var result = _context.Authors.Update(author).Entity;

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

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetPaginatedAuthors(int pageNumber, int pageSize)
        {
            return await _context.Authors
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Include(a => a.Books).ToListAsync();
        }
    }
}
