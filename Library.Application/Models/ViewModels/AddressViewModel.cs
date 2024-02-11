using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.ViewModels
{
    public record AddressViewModel
    {
        public Guid Id { get; init; }
        public Guid RegionId { get; init; }
        public string RegionName { get; init; } = string.Empty;
        public Guid CityId { get; init; }
        public string CityName { get; init; } = string.Empty;
        public Guid CountryId { get; init; }
        public string CountryName { get; init; } = string.Empty;
        public string? Block { get; init; }
        public string Street { get; init; } = string.Empty;
        public int HomeNumber { get; init; }
        public int? ApartmentNumber { get; init; }
        public DateTime CreatedTime { get; init; }
    }
}
