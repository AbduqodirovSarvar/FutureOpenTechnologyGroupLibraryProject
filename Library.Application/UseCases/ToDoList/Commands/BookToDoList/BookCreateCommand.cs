using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.BookToDoList
{
    public class BookCreateCommand : IRequest<BookViewModel>
    {
        public string GenreName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public Guid PublisherId { get; set; }
        public List<Guid> PublisherIds { get; set; } = new List<Guid>();
    }
}
