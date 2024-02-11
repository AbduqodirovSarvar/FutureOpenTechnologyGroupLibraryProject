using Library.Domain.Entities;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.AddressToDoList
{
    public class RegionCreateCommand : IRequest<Region>
    {
        public RegionCreateCommand(string regionName, string cityName, string countryName)
        {
            RegionName = regionName;
            CityName = cityName;
            CountryName = countryName;
        }
        public string RegionName { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
    }
}
