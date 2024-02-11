using Library.Application.Models.ViewModels;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Queries.AddressToDoList
{
    public class GetAllAddressQuery : IRequest<List<AddressViewModel>>
    {
        public GetAllAddressQuery() { }
    }
}
