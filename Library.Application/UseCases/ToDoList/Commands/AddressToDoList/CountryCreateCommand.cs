using Library.Domain.Entities;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.AddressToDoList
{
    public class CountryCreateCommand : IRequest<Country>
    {
        public CountryCreateCommand(string name)
        {
            CountryName = name;
        }
        public string CountryName { get; set; } = null!;
    }
}
