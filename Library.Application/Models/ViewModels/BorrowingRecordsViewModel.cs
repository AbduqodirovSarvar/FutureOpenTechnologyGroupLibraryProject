namespace Library.Application.Models.ViewModels
{
    public record BorrowingRecordsViewModel
    {
        public Guid Id { get; init; }
        public Guid StudentId { get; init; }
        public StudentViewModel Student { get; init; } = null!;
        public Guid BookId { get; init; }
        public BookViewModel Book { get; init; } = null!;
        public int Quantity { get; init; }
        public DateOnly DeadLine { get; init; }
        public bool IsReturned { get; init; }
        public decimal FineForBooks { get; init; }
        public DateTime CreatedTime { get; init; }
    }
}
