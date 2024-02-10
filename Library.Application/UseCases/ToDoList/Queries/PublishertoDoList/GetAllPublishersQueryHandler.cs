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

namespace Library.Application.UseCases.ToDoList.Queries.PublishertoDoList
{
    public class GetAllPublishersQueryHandler : IRequestHandler<GetAllPublishersQuery, List<PublisherViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPublishersQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<List<PublisherViewModel>> IRequestHandler<GetAllPublishersQuery, List<PublisherViewModel>>.Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
        {
            var publishers = await _context.Publishers
                                       .Include(x => x.Addresses)
                                       .ThenInclude(x => x.Address)
                                       .Include(x => x.Books)
                                       .Include(x => x.Contacts)
                                       .ToListAsync(cancellationToken);

            return _mapper.Map<List<PublisherViewModel>>(publishers);
        }
    }
}
