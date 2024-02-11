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
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email {  get; set; }
        public ICollection<AddressViewModel> Addresses {  get; set; } = new HashSet<AddressViewModel>();
        public ICollection<BorrowingRecordsViewModel> Borrows { get; set; } = new HashSet<BorrowingRecordsViewModel>();
        public DateTime CreatedTime { get; set; }
    }
}
