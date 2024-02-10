using Library.Application.UseCases.ToDoList.Commands.PublisherToDoList;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.ViewModels
{
    public record StudentViewModel
        (
            Guid Id,
            string FullName,
            string Email,
            ICollection<AddressViewModel> Addresses,
            ICollection<BorrowingRecordsViewModel> Borrows,
            DateTime CreatedTime
        );
}
