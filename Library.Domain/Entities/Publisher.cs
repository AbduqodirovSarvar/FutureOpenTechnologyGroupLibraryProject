using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Publisher : SubjectBase
    {
        public Publisher() : base(){ }

        public Publisher(string name)
        :base(name)
        {
        }
    }
}
