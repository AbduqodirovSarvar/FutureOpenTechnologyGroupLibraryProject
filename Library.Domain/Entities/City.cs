using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public sealed class City : SubjectBase
    {
        public City() { }

        public City(string name, Guid countryId)
            :base(name)
        {
            CountryId = countryId;
        }

        public Guid CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
