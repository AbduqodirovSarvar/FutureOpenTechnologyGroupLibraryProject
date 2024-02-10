using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
