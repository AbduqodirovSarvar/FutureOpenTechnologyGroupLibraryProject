using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.PublisherToDoList
{
    public class PublisherCreateCommandHandler : IRequestHandler<PublisherCreateCommand, PublisherViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PublisherCreateCommandHandler(IAppDbContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        async Task<PublisherViewModel> IRequestHandler<PublisherCreateCommand, PublisherViewModel>.Handle(PublisherCreateCommand request, CancellationToken cancellationToken)
        {
            var publisher = await _context.Publishers
                                            .Include(x => x.Addresses)
                                            .ThenInclude(x => x.Address)
                                            .FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken)
                                            ?? (await _context.Publishers.AddAsync(new Publisher(request.Name), cancellationToken)).Entity;

            var address = await _mediator.Send(new PublisherAddressCreateCommand()
            {
                PublisherId = publisher.Id,
                CountryName = request.CountryName,
                CityName = request.CityName,
                RegionName = request.RegionName,
                Block = request.Block,
                HomeNumber = request.HomeNumber,
                Street = request.Street,
                ApartmentNumber = request.ApartmentNumber
            }, cancellationToken);

            await _context.PublisherAddresses.AddAsync(new PublisherAddress(publisher.Id, address.Id), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PublisherViewModel>(publisher);
        }
    }
}
