using Library.Domain.Entities;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.AddressToDoList
{
    public class CityCreateCommand : IRequest<City>
    {
        public CityCreateCommand(string cityName, string countryName)
        {
            CityName = cityName;
            CountryName = countryName;
        }
        public string CityName { get; set; } = null!;

        public string CountryName { get; set; } = null!;
    }
}
