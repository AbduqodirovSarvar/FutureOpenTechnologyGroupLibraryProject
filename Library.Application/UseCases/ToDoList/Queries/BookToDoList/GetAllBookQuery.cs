using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.BookToDoList
{
    public class GetAllBookQuery : IRequest<List<BookViewModel>>
    {
        public GetAllBookQuery() { }
    }
}
