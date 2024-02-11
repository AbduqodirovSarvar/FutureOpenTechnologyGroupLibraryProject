using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class Genre : SubjectBase
    {
        public Genre() : base() { }

        public Genre(string name)
            : base(name)
        {
        }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
