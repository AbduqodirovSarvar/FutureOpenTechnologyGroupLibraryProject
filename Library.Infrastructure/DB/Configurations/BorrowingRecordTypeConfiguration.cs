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
    public class BorrowingRecordTypeConfiguration : IEntityTypeConfiguration<BorrowingRecord>
    {
        public void Configure(EntityTypeBuilder<BorrowingRecord> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.StudentId, x.BookId, x.Deadline }).IsUnique();
            builder.HasOne(x => x.Book).WithMany(x => x.BorrowingRecords).HasForeignKey(x => x.BookId);
            builder.HasOne(x => x.Student).WithMany(x => x.BorrowingRecords).HasForeignKey(x => x.StudentId);
        }
    }
}
