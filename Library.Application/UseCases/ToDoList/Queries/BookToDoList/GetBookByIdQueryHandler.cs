using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.UseCases.ToDoList.Queries.BookToDoList
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetBookByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BookViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books
                                    .Include(x => x.Genre)
                                    .Include(x => x.Authors)
                                    .ThenInclude(x => x.Author)
                                    .Include(x => x.Publisher)
                                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                    ?? throw new NotFoundException<Book>();

            return _mapper.Map<BookViewModel>(book);
        }
    }
}
