using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public sealed class StudentAddress : EntityBase
    {
        public StudentAddress() { }

        public StudentAddress(Guid studentId, Guid addressId)
            : base()
        {
            StudentId = studentId;
            AddressId = addressId;
        }
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
        public Guid AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
