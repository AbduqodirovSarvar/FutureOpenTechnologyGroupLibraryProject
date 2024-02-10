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

namespace Library.Application.UseCases.ToDoList.Queries.AuthorToDoList
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAppDbContext _context;
        public GetAuthorByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors
                                        .Include(x => x.Books)
                                        .ThenInclude(x => x.Book)
                                        .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                        ?? throw new NotFoundException<Author>();

            return author;
        }
    }
}
