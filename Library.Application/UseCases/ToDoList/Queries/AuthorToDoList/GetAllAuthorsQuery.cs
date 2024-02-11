using Library.Domain.Entities;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Queries.AuthorToDoList
{
    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {
        public GetAllAuthorsQuery() { }
    }
}
