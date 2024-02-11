using Library.Domain.Abstractions;

namespace Library.Domain.Entities
{
    public sealed class Student : PersonBase
    {
        public Student() { }

        public Student(string fullName, string email)
            : base(fullName, email)
        { }

        public ICollection<StudentAddress> StudentAddresses { get; set; } = new HashSet<StudentAddress>();
        public ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new HashSet<BorrowingRecord>();
    }
}
