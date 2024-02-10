using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.ViewModels
{
    public record AddressViewModel
        (
            Guid Id,
            Guid RegionId,
            string RegionName,
            Guid Cityid,
            string CityName,
            Guid CountryId,
            string CountryName,
            string? Block,
            string Street,
            int HomeNumber,
            int? ApartmentNumber,
            DateTime CreatedTime
        );
}
