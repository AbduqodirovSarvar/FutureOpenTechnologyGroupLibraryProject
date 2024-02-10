using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public sealed class Genre : SubjectBase
    {
        public Genre() : base() { }

        public Genre(string name)
            : base(name)
        {
        }
    }
}
