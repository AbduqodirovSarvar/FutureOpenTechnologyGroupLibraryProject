using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.DB.Configurations
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.RegionId, x.Block, x.Street, x.HomeNumber, x.ApartmentNumber }).IsUnique();
            builder.HasOne(x => x.Region).WithMany(x => x.Addresses).HasForeignKey(x => x.RegionId);
        }
    }
}
