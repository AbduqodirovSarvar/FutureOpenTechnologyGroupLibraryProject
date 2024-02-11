using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.DB.Configurations
{
    public class StudentAddressTypeConfiguration : IEntityTypeConfiguration<StudentAddress>
    {
        public void Configure(EntityTypeBuilder<StudentAddress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.StudentId, x.AddressId }).IsUnique();
            builder.HasOne(x => x.Student).WithMany(x => x.StudentAddresses).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Address).WithOne(x => x.Student).HasForeignKey<StudentAddress>(x => x.AddressId);
        }
    }
}
