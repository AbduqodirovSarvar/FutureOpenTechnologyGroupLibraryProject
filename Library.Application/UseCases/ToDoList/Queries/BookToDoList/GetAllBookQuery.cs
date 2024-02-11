using Library.Application.Models.ViewModels;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Queries.BookToDoList
{
    public class GetAllBookQuery : IRequest<List<BookViewModel>>
    {
        public GetAllBookQuery() { }
    }
}
