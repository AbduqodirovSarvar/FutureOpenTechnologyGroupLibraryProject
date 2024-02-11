using Library.Application.Models.ViewModels;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.BookToDoList
{
    public class BookCreateCommand : IRequest<BookViewModel>
    {
        public string GenreName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public Guid PublisherId { get; set; }
        public List<Guid> Authors { get; set; } = new List<Guid>();
    }
}
