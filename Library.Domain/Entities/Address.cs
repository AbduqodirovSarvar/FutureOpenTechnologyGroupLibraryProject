using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public sealed class Address : EntityBase
    {
        public Address() { }

        public Guid RegionId { get; set; }
        public Region? Region { get; set; }
        public string? Block {  get; set; }
        public string Street {  get; set; } = string.Empty;
        public int HomeNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public PublisherAddress? Publisher {  get; set; }
        public StudentAddress? Student { get; set; }
    }
}
