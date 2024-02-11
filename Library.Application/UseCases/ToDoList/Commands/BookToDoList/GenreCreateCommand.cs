using Library.Domain.Entities;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.BookToDoList
{
    public class GenreCreateCommand : IRequest<Genre>
    {
        public string Name { get; set; } = null!;
    }
}
