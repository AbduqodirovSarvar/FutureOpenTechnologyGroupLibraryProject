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
    public class CityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new {x.CountryId, x.Name}).IsUnique();
            builder.HasOne(x => x.Country).WithMany(x => x.Cities).HasForeignKey(x => x.CountryId);
        }
    }
}
