using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.ViewModels
{
    public record BookViewModel
        (
            Guid Id,
            string Title,
            Guid PublisherId,
            string PublisherName,
            Guid GenderId,
            string GenreName,
            ICollection<Author> Authors,
            DateTime CreatedTime
        );
}
