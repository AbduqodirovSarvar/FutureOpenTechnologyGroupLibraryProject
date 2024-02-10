using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstractions
{
    public abstract class PersonBase : EntityBase
    {
        public PersonBase() : base() { }

        public PersonBase(string fullName, string email)
            : base()
        {
            FullName = fullName;
            Email = email;
        }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
