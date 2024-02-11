using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.DB.Configurations
{
    public class PublisherTypeConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(x => x.Books).WithOne(x => x.Publisher).HasForeignKey(x => x.PublisherId);
            builder.HasMany(x => x.Addresses).WithOne(x => x.Publisher).HasForeignKey(x => x.PublisherId);
            builder.HasMany(x => x.Contacts).WithOne(x => x.Publisher).HasForeignKey(x => x.PublisherId);
        }
    }
}
