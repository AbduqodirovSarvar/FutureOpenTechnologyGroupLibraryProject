using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Guid GenreId {  get; set; }
        public Genre? Genre { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public ICollection<BookAuthor> Authors { get; set; } = new HashSet<BookAuthor>();
    }
}
