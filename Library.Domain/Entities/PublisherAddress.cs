using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public class PublisherAddress : EntityBase
    {
        public PublisherAddress() : base() { }

        public PublisherAddress(Guid publisherId, Guid addressId)
            : base()
        {
            PublisherId = publisherId;
            AddressId = addressId;
        }

        public Guid PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public Guid AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
