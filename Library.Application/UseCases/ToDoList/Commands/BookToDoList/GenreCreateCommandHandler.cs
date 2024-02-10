using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.BookToDoList
{
    public class GenreCreateCommandHandler : IRequestHandler<GenreCreateCommand, Genre>
    {
        private readonly IAppDbContext _context;
        public GenreCreateCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Genre> Handle(GenreCreateCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres
                                    .FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken)
                                    ?? (await _context.Genres.AddAsync(new Genre(request.Name), cancellationToken)).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return genre;
        }
    }
}
