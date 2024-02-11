using Library.Application.Models.ViewModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.ToDoList.Queries.BorrowingToDoList
{
    public class GetBorrowByIdQuery : IRequest<BorrowingRecordsViewModel>
    {
        public GetBorrowByIdQuery(Guid id)
        {
            Id = id;
        }
        [Required]
        public Guid Id { get; set; }
    }
}
