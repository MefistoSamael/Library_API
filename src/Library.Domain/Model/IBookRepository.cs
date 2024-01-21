using Library.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Model
{
    public interface IBookRepository : IRepository<Book>
    {
        Book Add(Book book);

        Book Update(Book book);

        Book Delete(Book book);

        Task<Book?> GetAsyncById(int bookId);

        Task<Book?> GetAsyncByISBN(string ISBN);
    }
}
