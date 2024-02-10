using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public sealed class BorrowingRecord : EntityBase
    {
        public BorrowingRecord() : base() { }

        public BorrowingRecord(Guid studentId, Guid bookId, DateOnly deadline, int? quantity)
            : base()
        {
            StudentId = studentId;
            BookId = bookId;
            Deadline = deadline;
            Quantity = quantity ?? 1;
        }

        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
        public Guid BookId { get; set; }
        public Book? Book { get; set; }
        public int Quantity { get; set; } = 1;
        public DateOnly Deadline { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow).AddDays(7);
        public bool IsReturned { get; set; } = false;
        public decimal FineForBooks { get; set; } = 0;
    }
}
