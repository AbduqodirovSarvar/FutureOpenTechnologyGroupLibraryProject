using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.AddressToDoList
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery, List<AddressViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllAddressQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AddressViewModel>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _context.Addresss
                                          .Include(x => x.Region)
                                          .ThenInclude(x => x != null ? x.City : null)
                                          .ThenInclude(x => x != null ? x.Country : null)
                                          .ToListAsync(cancellationToken);

            return _mapper.Map<List<AddressViewModel>>(addresses);
        }
    }
}
