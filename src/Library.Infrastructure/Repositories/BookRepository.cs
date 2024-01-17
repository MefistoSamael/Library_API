﻿using Library.Domain.Model;
using Library.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public IUnitOfWork UnitOfWork
        { 
            get
            {
                return _context;
            }
        }

        public BookRepository(LibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Book Add(Book book)
        {
            return _context.Books.Add(book).Entity;
        }

        public Book Delete(Book book)
        {
            return _context.Books.Remove(book).Entity;
        }

        public async Task<Book> GetAsyncById(int bookId)
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<Book>? GetAsyncByISBN(string ISBN)
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.ISBN == ISBN);
        }

        public Book Update(Book book)
        {
            //_context.Entry(book).CurrentValues.SetValues(book);
            _context.Entry(book).State = EntityState.Modified;
            return book;
        }
    }
}