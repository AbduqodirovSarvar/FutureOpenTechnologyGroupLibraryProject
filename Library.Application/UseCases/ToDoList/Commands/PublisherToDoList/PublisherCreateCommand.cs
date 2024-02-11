using Library.Application.Models.ViewModels;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.PublisherToDoList
{
    public class PublisherCreateCommand : IRequest<PublisherViewModel>
    {
        public string Name { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string RegionName { get; set; } = null!;
        public string? Block { get; set; }
        public string Street { get; set; } = null!;
        public int HomeNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}
