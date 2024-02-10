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
    public class PublisherAddressTypeConfiguration : IEntityTypeConfiguration<PublisherAddress>
    {
        public void Configure(EntityTypeBuilder<PublisherAddress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new {x.PublisherId, x.AddressId}).IsUnique();
            builder.HasOne(x => x.Publisher).WithMany(x => x.Addresses).HasForeignKey(x => x.PublisherId);
            builder.HasOne(x => x.Address).WithOne(x => x.Publisher).HasForeignKey<PublisherAddress>(x => x.AddressId);
        }
    }
}
