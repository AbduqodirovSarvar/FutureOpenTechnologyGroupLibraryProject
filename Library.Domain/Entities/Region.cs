using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
