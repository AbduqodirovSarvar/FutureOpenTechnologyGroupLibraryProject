using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.BookToDoList
{
    public class GetBookByIdQuery : IRequest<BookViewModel>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
