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
            bookConfiguration.ToTable(t => t.HasCheckConstraint("ValidTime", "BorrowingTime < ReturningTime")
                                            .HasName("books"));

            bookConfiguration.Property(b => b.Id).UseHiLo();

            bookConfiguration.HasKey(b => b.Id);
            
            bookConfiguration.HasIndex(b => b.ISBN).IsUnique();


            bookConfiguration.Property(b => b.Name).IsRequired();
            bookConfiguration.Property(b => b.ISBN).HasMaxLength(13)
                                                   .IsRequired();
            bookConfiguration.Property(b => b.Genre).IsRequired();
            bookConfiguration.Property(b => b.Description).IsRequired();
            bookConfiguration.Property(b => b.Author).IsRequired();
            bookConfiguration.Property(b => b.BorrowingTime).IsRequired();
            bookConfiguration.Property(b => b.ReturningTime).IsRequired();
        }
    }
}
