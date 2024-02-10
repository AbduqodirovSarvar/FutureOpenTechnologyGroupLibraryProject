using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.AuthorToDoList
{
    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {
        public GetAllAuthorsQuery() { }
    }
}
