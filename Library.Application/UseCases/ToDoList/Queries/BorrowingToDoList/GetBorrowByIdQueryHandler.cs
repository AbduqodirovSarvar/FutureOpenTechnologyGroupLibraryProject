using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.UseCases.ToDoList.Queries.BorrowingToDoList
{
    public class GetBorrowByIdQueryHandler : IRequestHandler<GetBorrowByIdQuery, BorrowingRecordsViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetBorrowByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BorrowingRecordsViewModel> Handle(GetBorrowByIdQuery request, CancellationToken cancellationToken)
        {
            var borrow = await _context.BorrowingRecords
                                       .Include(x => x.Book)
                                       .Include(x => x.Student)
                                       .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                       ?? throw new NotFoundException<BorrowingRecord>();

            return _mapper.Map<BorrowingRecordsViewModel>(borrow);
        }
    }
}
