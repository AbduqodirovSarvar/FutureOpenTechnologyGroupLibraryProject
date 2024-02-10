using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.PublishertoDoList
{
    public class GetPublisherByIdQueryHandler : IRequestHandler<GetPublisherByIdQuery, PublisherViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetPublisherByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<PublisherViewModel> IRequestHandler<GetPublisherByIdQuery, PublisherViewModel>.Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            var publisher = await _context.Publishers
                                        .Include(x => x.Addresses)
                                       .ThenInclude(x => x.Address)
                                       .Include(x => x.Books)
                                       .Include(x => x.Contacts)
                                       .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                       ?? throw new NotFoundException<Publisher>();

            return _mapper.Map<PublisherViewModel>(publisher);
        }
    }
}
