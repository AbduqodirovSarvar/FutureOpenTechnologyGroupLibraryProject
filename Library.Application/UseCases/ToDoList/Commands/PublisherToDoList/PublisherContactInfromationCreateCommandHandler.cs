using Library.Application.Abstractions;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.PublisherToDoList
{
    public class PublisherContactInfromationCreateCommandHandler : IRequestHandler<PublisherContactInformationCreateCommand, ContactInformation>
    {
        private readonly IAppDbContext _context;

        public PublisherContactInfromationCreateCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ContactInformation> Handle(PublisherContactInformationCreateCommand request, CancellationToken cancellationToken)
        {
            var publisher = await _context.Publishers
                                        .FirstOrDefaultAsync(x => x.Id == request.PublisherId, cancellationToken) ?? throw new NotFoundException<Publisher>();

            var contactInformation = await _context.ContactInformations
                                                .FirstOrDefaultAsync(x => x.Name == request.Name && x.PublisherId == request.PublisherId, cancellationToken)
                                                ?? (await _context.ContactInformations
                                                .AddAsync(new ContactInformation(request.Name, request.Contact, request.PublisherId), cancellationToken)).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return contactInformation;
        }
    }
}
