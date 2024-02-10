using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.ViewModels
{
    public record PublisherViewModel
        (
            Guid Id,
            string Name,
            ICollection<BookViewModel> Books,
            ICollection<AddressViewModel> Addresses,
            ICollection<ContactInformation> Contacts,
            DateTime CreatedTime
        );
}
