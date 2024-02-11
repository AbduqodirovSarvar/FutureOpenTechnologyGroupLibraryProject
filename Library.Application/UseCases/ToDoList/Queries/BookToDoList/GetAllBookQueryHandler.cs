using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.UseCases.ToDoList.Queries.BookToDoList
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, List<BookViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllBookQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookViewModel>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books
                                        .Include(x => x.Genre)
                                        .Include(x => x.Publisher)
                                        .Include(x => x.Authors)
                                        .ThenInclude(x => x.Author)
                                        .ToListAsync(cancellationToken);

            return _mapper.Map<List<BookViewModel>>(books);
        }
    }
}
