using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class ContactInformation : SubjectBase
    {
        public ContactInformation() : base() { }

        public ContactInformation(string name, string contact, Guid publisherId)
            : base(name)
        {
            Contact = contact;
            PublisherId = publisherId;
        }

        public string Contact { get; set; } = string.Empty;
        public Guid PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
