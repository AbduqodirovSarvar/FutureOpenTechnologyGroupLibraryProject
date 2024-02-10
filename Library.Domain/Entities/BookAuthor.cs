using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
