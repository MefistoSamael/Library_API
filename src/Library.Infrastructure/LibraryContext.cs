﻿using Library.Domain.Model;
using Library.Domain.SeedWork;
using Library.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
        }
    }
}