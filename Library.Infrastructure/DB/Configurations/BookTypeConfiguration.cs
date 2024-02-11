using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.DB.Configurations
{
    public class BookTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.GenreId, x.Title }).IsUnique();
            builder.HasOne(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.PublisherId);
            builder.HasOne(x => x.Genre).WithMany(x => x.Books).HasForeignKey(x => x.GenreId);
            builder.HasMany(x => x.Authors).WithOne(x => x.Book).HasForeignKey(x => x.BookId);
            builder.HasMany(x => x.BorrowingRecords).WithOne(x => x.Book).HasForeignKey(x => x.BookId);
        }
    }
}
