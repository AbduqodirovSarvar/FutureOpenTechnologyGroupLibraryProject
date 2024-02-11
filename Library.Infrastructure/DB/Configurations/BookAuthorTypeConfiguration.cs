using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.DB.Configurations
{
    public class BookAuthorTypeConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.AuthorId, x.BookId }).IsUnique();
            builder.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
            builder.HasOne(x => x.Book).WithMany(x => x.Authors).HasForeignKey(x => x.BookId);
        }
    }
}
