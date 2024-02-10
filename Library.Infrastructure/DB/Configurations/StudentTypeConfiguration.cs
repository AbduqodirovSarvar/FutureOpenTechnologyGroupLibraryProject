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
    public class StudentTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasMany(x => x.BorrowingRecords).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            builder.HasMany(x => x.StudentAddresses).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
        }
    }
}
