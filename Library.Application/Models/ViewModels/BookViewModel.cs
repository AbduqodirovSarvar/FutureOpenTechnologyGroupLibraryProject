using Library.Domain.Entities;

namespace Library.Application.Models.ViewModels
{
    public record BookViewModel
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public Guid PublisherId { get; init; }
        public string PublisherName { get; init; } = string.Empty;
        public Guid GenderId { get; init; }
        public string GenreName { get; init; } = string.Empty;
        public ICollection<Author> Authors { get; init; } = new HashSet<Author>();
        public DateTime CreatedTime { get; init; }
    }
}
