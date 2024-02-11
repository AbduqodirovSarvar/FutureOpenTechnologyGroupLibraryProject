using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class Address : EntityBase
    {
        public Address() { }

        public Guid RegionId { get; set; }
        public Region? Region { get; set; }
        public string? Block { get; set; }
        public string Street { get; set; } = string.Empty;
        public int HomeNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public PublisherAddress? Publisher { get; set; }
        public StudentAddress? Student { get; set; }
    }
}
