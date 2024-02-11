using Library.Domain.Models.BookModel;

namespace Library.API.Application.Books.Queries
{
    public class PaginatedBooks
    {
        public IEnumerable<Book> books { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }

        public PaginatedBooks(IEnumerable<Book> books, int currentPage, int totalPages)
        {
            this.books = books;
            this.currentPage = currentPage;
            this.totalPages = totalPages;
        }
    }
}
