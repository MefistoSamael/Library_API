﻿using Library.Domain.Model;

namespace Library.API.Application.Queries
{
    public class BookDTO
    {
        public IEnumerable<Book> books { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }

        public BookDTO(IEnumerable<Book> books, int currentPage, int totalPages)
        {
            this.books = books;
            this.currentPage = currentPage;
            this.totalPages = totalPages;
        }
    }
}
