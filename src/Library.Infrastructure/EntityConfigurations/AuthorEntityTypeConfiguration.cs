using Library.Domain.Models.AuthorModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigurations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> authorConfiguration)
        {
            authorConfiguration.ToTable("authors");

            authorConfiguration.HasKey(x => x.Id);
            
            authorConfiguration.Property(a => a.Name).IsRequired();
        }
    }
}
