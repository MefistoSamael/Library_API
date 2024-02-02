using Library.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Model
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);

        Task<Book> UpdateAsync(Book book);

        Task DeleteAsync(Book book);

        Task<Book?> GetAsyncById(int bookId);

        Task<Book?> GetAsyncByISBN(string ISBN);
    }
}
