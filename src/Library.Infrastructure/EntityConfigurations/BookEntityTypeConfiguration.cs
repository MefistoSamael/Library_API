using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.EntityConfigurations
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> bookConfiguration)
        {
            bookConfiguration.ToTable("books");

            bookConfiguration.Property(b => b.Id).UseHiLo();

            bookConfiguration.HasKey(b => b.Id);
            
            bookConfiguration.HasIndex(b => b.ISBN).IsUnique();

            bookConfiguration.HasData(
                new
                {
                    Id = 1,
                    ISBN = "1111111111",
                    Name = "First Book",
                    Genre = "Comedy",
                    Description = "Awesome comedy book",
                    Author = "John Johnson",
                    BorrowingTime = new DateTime(2, 2, 2),
                    ReturningTime = new DateTime(3, 3, 3)
                },
                new
                {
                    Id = 2,
                    ISBN = "2222222222",
                    Name = "Second Book",
                    Genre = "Horror",
                    Description = "Outrageous book",
                    Author = "Karl Young",
                    BorrowingTime = new DateTime(4, 4, 4),
                    ReturningTime = new DateTime(5, 5, 5)
                },
                new
                {
                    Id = 3,
                    ISBN = "333333333",
                    Name = "Third Book",
                    Genre = "Detective",
                    Description = "Brilliant book",
                    Author = "Klara",
                    BorrowingTime = new DateTime(6, 6, 6),
                    ReturningTime = new DateTime(7, 7, 7)
                }
                );

            // Didnt configurated explicitly other fields of Book entity
            // because it's not necessary - fileds will be required because
            // the are not null, and names are good
        }
    }
}
