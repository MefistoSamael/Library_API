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

            // Didnt configurated explicitly other fields of Book entity
            // because it's not necessary - fileds will be required because
            // the are not null, and names are good
        }
    }
}
