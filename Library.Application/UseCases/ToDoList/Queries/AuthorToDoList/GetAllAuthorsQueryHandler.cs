using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.UseCases.ToDoList.Queries.AuthorToDoList
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IAppDbContext _context;
        public GetAllAuthorsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _context.Authors
                                        .Include(x => x.Books)
                                        .ThenInclude(x => x.Book)
                                        .ToListAsync(cancellationToken);

            return authors;
        }
    }
}
