using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.AddressToDoList
{
    public class AddressCreateCommandHandler : IRequestHandler<AddressCreateCommand, AddressViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;

        public AddressCreateCommandHandler(
            IAppDbContext context,
            IMediator mediator,
            ICurrentUser currentUser,
            IMapper mapper
            )
        {
            _context = context;
            _mediator = mediator;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<AddressViewModel> Handle(AddressCreateCommand request, CancellationToken cancellationToken)
        {
            var region = await _mediator.Send(new RegionCreateCommand(request.RegionName, request.CityName, request.CountryName), cancellationToken);

            var address = new Address()
            {
                RegionId = region.Id,
                Region = region,
                Block = request.Block,
                Street = request.Street,
                HomeNumber = request.HomeNumber,
                ApartmentNumber = request.ApartmentNumber
            };

            await _context.Addresss.AddAsync(address, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AddressViewModel>(address);
        }
    }
}
