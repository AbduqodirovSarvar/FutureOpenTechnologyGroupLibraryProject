using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class Book : SubjectBase
    {
        public Book() : base() { }

        public Book(string title, Guid genreId, Guid publisherId)
            : base()
        {
            Title = title;
            GenreId = genreId;
            PublisherId = publisherId;
        }
        public string Title { get; set; } = null!;
        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public ICollection<BookAuthor> Authors { get; set; } = new HashSet<BookAuthor>();
        public ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new HashSet<BorrowingRecord>();
    }
}
