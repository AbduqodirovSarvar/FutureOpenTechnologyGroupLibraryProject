using Library.Domain.Entities;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.AuthorToDoList
{
    public class AuthorCreateCommand : IRequest<Author>
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Biograpyh { get; set; } = null;
    }
}
