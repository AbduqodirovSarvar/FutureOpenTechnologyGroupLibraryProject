using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.StudentToDoList
{
    public class GetAllStudentsQuery : IRequest<List<StudentViewModel>>
    {
        public GetAllStudentsQuery() { }
    }
}
