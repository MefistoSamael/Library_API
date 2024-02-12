using Library.Domain.Models.AuthorModel;
using Library.Domain.Models.BookModel;

namespace Library.API.Application.Common
{
#pragma warning disable CS8618
    public class BookDTO
    {
        public int BookId { get; set; }

        public string ISBN { get; set; }

        public string BookName { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        public DateTime BorrowingTime { get; set; }

        public DateTime ReturningTime { get; set; }
    }

    public class AuthorDTO
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public List<BookDTO> Books { get; set; }
    }
#pragma warning restore CS8618

    public class PaginatedResult<T>
    {
        public required IEnumerable<T> collection { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }
    }
}
