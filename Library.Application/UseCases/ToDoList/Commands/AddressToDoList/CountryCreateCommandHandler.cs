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
    public class CountryCreateCommandHandler : IRequestHandler<CountryCreateCommand, Country>
    {
        private readonly IAppDbContext _context;

        public CountryCreateCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Country> Handle(CountryCreateCommand request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries
                                        .FirstOrDefaultAsync(x => x.Name == request.CountryName, cancellationToken);
            if (country == null)
            {
                country = new Country { Name = request.CountryName };
                await _context.Countries.AddAsync(country, cancellationToken);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return country;
        }
    }
}
