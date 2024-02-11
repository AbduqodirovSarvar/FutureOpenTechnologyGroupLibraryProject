using Library.Domain.Entities;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.PublisherToDoList
{
    public class PublisherAddressCreateCommand : IRequest<PublisherAddress>
    {
        public Guid PublisherId { get; set; }
        public string CountryName { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string RegionName { get; set; } = null!;
        public string? Block { get; set; }
        public string Street { get; set; } = null!;
        public int HomeNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}
