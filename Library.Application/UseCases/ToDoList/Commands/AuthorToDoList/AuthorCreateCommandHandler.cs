using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.AuthorToDoList
{
    public class AuthorCreateCommandHandler : IRequestHandler<AuthorCreateCommand, Author>
    {
        private readonly IAppDbContext _context;

        public AuthorCreateCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Author> Handle(AuthorCreateCommand request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (author == null)
            {
                author = new Author(request.FullName, request.Email, request.Biograpyh);
                await _context.Authors.AddAsync(author, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return author;
        }
    }
}
