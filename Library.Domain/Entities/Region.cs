using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class Region : SubjectBase
    {
        public Region() { }

        public Region(string name, Guid cityId)
            : base(name)
        {
            CityId = cityId;
        }
        public Guid CityId { get; set; }
        public City? City { get; set; }
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
