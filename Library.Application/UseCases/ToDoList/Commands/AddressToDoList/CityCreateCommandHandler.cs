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
    public class CityCreateCommandHandler : IRequestHandler<CityCreateCommand, City>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;

        public CityCreateCommandHandler(IAppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<City> Handle(CityCreateCommand request, CancellationToken cancellationToken)
        {
            var country = await _mediator.Send(new CountryCreateCommand(request.CountryName), cancellationToken);
            var city = await _context.Cities
                                     .Include(x => x.Country)
                                     .FirstOrDefaultAsync(x => x.Name == request.CityName && x.CountryId == country.Id, cancellationToken);

            if (city == null)
            {
                city = new City(request.CityName, country.Id);
                await _context.Cities.AddAsync(city, cancellationToken);
            }
            await _context.SaveChangesAsync(cancellationToken);

            return city;
        }
    }
}
