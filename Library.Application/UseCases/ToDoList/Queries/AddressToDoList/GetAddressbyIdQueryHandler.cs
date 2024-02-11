using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.UseCases.ToDoList.Queries.AddressToDoList
{
    public class GetAddressbyIdQueryHandler : IRequestHandler<GetAddressbyIdQuery, AddressViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAddressbyIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddressViewModel> Handle(GetAddressbyIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _context.Addresss
                                        .Include(x => x.Region)
                                        .ThenInclude(x => x != null ? x.City : null)
                                        .ThenInclude(x => x != null ? x.Country : null)
                                        .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                        ?? throw new NotFoundException<Address>();

            return _mapper.Map<AddressViewModel>(address);
        }
    }
}
