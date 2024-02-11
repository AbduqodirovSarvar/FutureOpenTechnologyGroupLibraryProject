using Library.Domain.Entities;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.BookToDoList
{
    public class BookAuthorCreateCommand : IRequest<BookAuthor>
    {
        public BookAuthorCreateCommand(Guid bookId, Guid authorId)
        {
            BookId = bookId;
            AuthorId = authorId;
        }
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
