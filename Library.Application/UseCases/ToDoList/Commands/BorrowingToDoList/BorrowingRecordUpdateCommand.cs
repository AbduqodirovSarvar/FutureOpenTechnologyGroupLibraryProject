using Library.Application.Models.ViewModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.ToDoList.Commands.BorrowingToDoList
{
    public class BorrowingRecordUpdateCommand : IRequest<BorrowingRecordsViewModel>
    {
        [Required]
        public Guid Id { get; set; }
        public int? Quantity { get; set; } = null;
        public bool IsReturned { get; set; } = false;
        public DateOnly? Deadline { get; set; } = null;
    }
}
