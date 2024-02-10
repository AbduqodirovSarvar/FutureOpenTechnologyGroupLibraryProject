using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.BookToDoList
{
    public class BookAuthorCreateCommand : IRequest<BookAuthor>
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
