using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class BookAuthor : EntityBase
    {
        public BookAuthor() { }

        public BookAuthor(Guid bookId, Guid authorId)
            : base()
        {
            BookId = bookId;
            AuthorId = authorId;
        }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }
        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
