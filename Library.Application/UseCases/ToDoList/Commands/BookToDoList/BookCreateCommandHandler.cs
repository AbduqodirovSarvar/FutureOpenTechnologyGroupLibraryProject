using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
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
    public class BookCreateCommandHandler : IRequestHandler<BookCreateCommand, BookViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookCreateCommandHandler(IAppDbContext context, IMediator mediator, IMapper mapper)
        {
             _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<BookViewModel> Handle(BookCreateCommand request, CancellationToken cancellationToken)
        {
            var genre = await _mediator.Send(new GenreCreateCommand()
                                        {
                                            Name = request.GenreName
                                        }, cancellationToken);

            var book = await _context.Books
                                    .FirstOrDefaultAsync(x => x.GenreId == genre.Id && x.Title == request.Title, cancellationToken)
                                    ?? (await _context.Books.AddAsync(new Book(request.Title, genre.Id, request.PublisherId), cancellationToken)).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BookViewModel>(book);
        }
    }
}
