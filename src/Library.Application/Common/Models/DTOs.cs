namespace Library.Application.Common.Models
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
        public required IEnumerable<T> Collection { get; set; }

        public required int CurrentPage { get; set; }
        
        public required int TotalPageCount { get; set; }

        public required int TotalItemCount {  get; set; }

        public required int PageSize { get; set;}
    }
}
