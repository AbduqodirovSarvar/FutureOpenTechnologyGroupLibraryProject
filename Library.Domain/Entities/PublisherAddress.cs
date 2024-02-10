using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
