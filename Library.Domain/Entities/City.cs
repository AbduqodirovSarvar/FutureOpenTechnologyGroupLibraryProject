using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class City : SubjectBase
    {
        public City() { }

        public City(string name, Guid countryId)
            : base(name)
        {
            CountryId = countryId;
        }

        public Guid CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<Region> Regions { get; set; } = new HashSet<Region>();
    }
}
