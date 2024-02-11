using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.ViewModels
{
    public record PublisherViewModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public ICollection<BookViewModel> Books { get; init; } = new HashSet<BookViewModel>();
        public ICollection<AddressViewModel> Addresses { get; init; } = new HashSet<AddressViewModel>();
        public ICollection<ContactInformation> Contacts { get; init; } = new HashSet<ContactInformation>();
        public DateTime CreatedTime { get; init; }
    }
}
