using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class Country : SubjectBase
    {
        public Country() : base() { }

        public Country(string name) : base(name) { }

        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
