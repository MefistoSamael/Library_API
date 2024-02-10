using Library.Domain.Models.BookModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigurations
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> bookConfiguration)
        {
            bookConfiguration.ToTable(t => t.HasCheckConstraint("ValidTime", "BorrowingTime < ReturningTime")
                                            .HasName("TimeValidation"));

            bookConfiguration.Property(b => b.Id).UseHiLo();

            bookConfiguration.HasKey(b => b.Id);
            
            bookConfiguration.HasIndex(b => b.ISBN).IsUnique();


            bookConfiguration.Property(b => b.Name).IsRequired();
            bookConfiguration.Property(b => b.ISBN).HasMaxLength(13)
                                                   .IsRequired();
            bookConfiguration.Property(b => b.Genre).IsRequired();
            bookConfiguration.Property(b => b.Description).IsRequired();
            bookConfiguration.Property(b => b.AuthorId).IsRequired();
            
            bookConfiguration.HasOne(b => b.Author).WithMany(a => a.Books).OnDelete(DeleteBehavior.Restrict);
            
            bookConfiguration.Property(b => b.BorrowingTime).IsRequired();
            bookConfiguration.Property(b => b.ReturningTime).IsRequired();
        }
    }
}
