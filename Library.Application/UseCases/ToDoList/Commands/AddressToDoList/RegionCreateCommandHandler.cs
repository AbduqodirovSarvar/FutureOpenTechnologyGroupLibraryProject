using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.AddressToDoList
{
    public class RegionCreateCommandHandler : IRequestHandler<RegionCreateCommand, Region>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;
        public RegionCreateCommandHandler(IAppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<Region> Handle(RegionCreateCommand request, CancellationToken cancellationToken)
        {
            var city = await _mediator.Send(new CityCreateCommand(request.CityName, request.CountryName), cancellationToken);
            var region = await _context.Regions
                                       .Include(x => x.City)
                                       .ThenInclude(x => x != null ? x.Country : null)
                                       .FirstOrDefaultAsync(x => x.Name == request.RegionName && x.CityId == city.Id, cancellationToken);
            if (region == null)
            {
                region = new Region(request.RegionName, city.Id);
                await _context.Regions.AddAsync(region, cancellationToken);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return region;
        }
    }
}
