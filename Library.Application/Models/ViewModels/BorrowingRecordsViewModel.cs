using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.ViewModels
{
    public record BorrowingRecordsViewModel
        (
            Guid Id,
            Guid StudentId,
            StudentViewModel Student,
            Guid BookId,
            BookViewModel Book,
            int Quantity,
            DateOnly Deadline,
            bool IsReturned,
            decimal FineForBooks,
            DateTime CreatedTime
        );
}
