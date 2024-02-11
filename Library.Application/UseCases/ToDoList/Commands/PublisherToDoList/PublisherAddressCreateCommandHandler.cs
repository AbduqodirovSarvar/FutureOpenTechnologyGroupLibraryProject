using Library.Application.Abstractions;
using Library.Application.UseCases.ToDoList.Commands.AddressToDoList;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.UseCases.ToDoList.Commands.PublisherToDoList
{
    public class PublisherAddressCreateCommandHandler : IRequestHandler<PublisherAddressCreateCommand, PublisherAddress>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;

        public PublisherAddressCreateCommandHandler(IAppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<PublisherAddress> Handle(PublisherAddressCreateCommand request, CancellationToken cancellationToken)
        {
            var address = await _mediator.Send(new AddressCreateCommand()
            {
                CountryName = request.CountryName,
                CityName = request.CityName,
                RegionName = request.RegionName,
                Block = request.Block,
                HomeNumber = request.HomeNumber,
                Street = request.Street,
                ApartmentNumber = request.ApartmentNumber
            }, cancellationToken);

            var publisherAddress = await _context.PublisherAddresses
                                                .FirstOrDefaultAsync(x => x.AddressId == address.Id && x.PublisherId == request.PublisherId, cancellationToken)
                                                ?? (await _context.PublisherAddresses.AddAsync(new PublisherAddress(request.PublisherId, address.Id), cancellationToken)).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return publisherAddress;
        }
    }
}
