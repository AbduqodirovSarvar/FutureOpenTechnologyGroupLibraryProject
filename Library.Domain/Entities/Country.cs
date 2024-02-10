using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public sealed class Country : SubjectBase
    {
        public Country() : base(){ }

        public Country(string name) : base(name) { }

        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
