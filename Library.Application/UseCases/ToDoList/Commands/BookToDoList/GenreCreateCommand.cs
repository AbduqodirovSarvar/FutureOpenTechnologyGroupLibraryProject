using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.BookToDoList
{
    public class GenreCreateCommand : IRequest<Genre>
    {
        public string Name { get; set; } = null!;
    }
}
