using Library.Application.Models.ViewModels;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Queries.StudentToDoList
{
    public class GetAllStudentsQuery : IRequest<List<StudentViewModel>>
    {
        public GetAllStudentsQuery() { }
    }
}
