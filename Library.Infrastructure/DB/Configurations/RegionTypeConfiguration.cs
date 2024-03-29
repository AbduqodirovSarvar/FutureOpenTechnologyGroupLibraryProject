﻿using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.DB.Configurations
{
    public class RegionTypeConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.CityId, x.Name }).IsUnique();
            builder.HasOne(x => x.City).WithMany(x => x.Regions).HasForeignKey(x => x.CityId);
        }
    }
}
