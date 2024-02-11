using Library.Domain.Abstractions;

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
