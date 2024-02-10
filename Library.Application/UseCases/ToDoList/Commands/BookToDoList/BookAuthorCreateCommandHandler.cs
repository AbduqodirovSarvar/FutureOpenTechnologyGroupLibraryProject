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
    public class BookAuthorCreateCommandHandler : IRequestHandler<BookAuthorCreateCommand, BookAuthor>
    {
        private readonly IAppDbContext _context;

        public BookAuthorCreateCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<BookAuthor> Handle(BookAuthorCreateCommand request, CancellationToken cancellationToken)
        {
            var bookAuthor = await _context.BookAuthors
                                           .FirstOrDefaultAsync(x => x.AuthorId == request.AuthorId && x.BookId == request.BookId, cancellationToken)
                                           ?? (await _context.BookAuthors.AddAsync(new BookAuthor(request.BookId, request.AuthorId), cancellationToken)).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return bookAuthor;
        }
    }
}
