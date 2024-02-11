using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public class Publisher : SubjectBase
    {
        public Publisher() : base() { }

        public Publisher(string name)
        : base(name)
        {
        }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
        public ICollection<PublisherAddress> Addresses { get; set; } = new HashSet<PublisherAddress>();
        public ICollection<ContactInformation> Contacts { get; set; } = new HashSet<ContactInformation>();
    }
}
