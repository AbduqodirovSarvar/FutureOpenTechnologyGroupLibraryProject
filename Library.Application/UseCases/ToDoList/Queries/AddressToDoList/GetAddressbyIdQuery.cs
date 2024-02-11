using Library.Application.Models.ViewModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.ToDoList.Queries.AddressToDoList
{
    public class GetAddressbyIdQuery : IRequest<AddressViewModel>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
