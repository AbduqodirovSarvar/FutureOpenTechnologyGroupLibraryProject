using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.BorrowingToDoList
{
    public class BorrowingRecordCreateCommand : IRequest<BorrowingRecordsViewModel>
    {
        public Guid BookId { get; set; }
        public Guid StudentId { get; set; }
        public int Quantity { get; set; } = 0;
        public DateOnly DeadLine { get; set; }
    }
}
