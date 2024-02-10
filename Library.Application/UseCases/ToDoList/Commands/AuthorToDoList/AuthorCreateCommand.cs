using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.AuthorToDoList
{
    public class AuthorCreateCommand : IRequest<Author>
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Biograpyh { get; set; } = null;
    }
}
