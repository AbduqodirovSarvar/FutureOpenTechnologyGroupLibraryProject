namespace Library.Application.Models.ViewModels
{
    public record StudentViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<AddressViewModel> Addresses { get; set; } = new HashSet<AddressViewModel>();
        public ICollection<BorrowingRecordsViewModel> Borrows { get; set; } = new HashSet<BorrowingRecordsViewModel>();
        public DateTime CreatedTime { get; set; }
    }
}
