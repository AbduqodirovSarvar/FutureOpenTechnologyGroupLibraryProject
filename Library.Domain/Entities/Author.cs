using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class Author : PersonBase
    {
        public Author() : base() { }

        public Author(string fullName, string email, string? biography)
            : base(fullName, email)
        {
            Biography = biography;
        }
        public string? Biography { get; set; }
        public ICollection<BookAuthor> Books { get; set; } = new HashSet<BookAuthor>();
    }
}
