using Library.Application.Abstractions;
using Library.Application.UseCases.ToDoList.Commands.AddressToDoList;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.StudentToDoList
{
    public class StudentAddressCreateCommandHandler : IRequestHandler<StudentAddressCreateCommand, StudentAddress>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;

        public StudentAddressCreateCommandHandler(IAppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<StudentAddress> Handle(StudentAddressCreateCommand request, CancellationToken cancellationToken)
        {
            var address = await _mediator.Send(new AddressCreateCommand()
                                        {
                                            CountryName = request.CountryName,
                                            CityName = request.CityName,
                                            RegionName = request.RegionName,
                                            Block = request.Block,
                                            Street = request.Street,
                                            HomeNumber = request.HomeNumber,
                                            ApartmentNumber = request.ApartmentNumber
                                        }, cancellationToken);

            var studentAddress = await _context.StudentAddresses
                                                .FirstOrDefaultAsync(x => x.StudentId == request.StudentId && x.AddressId == address.Id, cancellationToken)
                                                ?? (await _context.StudentAddresses.AddAsync(new StudentAddress(request.StudentId, address.Id), cancellationToken)).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return studentAddress;
        }
    }
}
