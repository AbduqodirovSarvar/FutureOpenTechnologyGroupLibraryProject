using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.BorrowingToDoList
{
    public class BorrowingRecordUpdateCommandHandler : IRequestHandler<BorrowingRecordUpdateCommand, BorrowingRecordsViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public BorrowingRecordUpdateCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BorrowingRecordsViewModel> Handle(BorrowingRecordUpdateCommand request, CancellationToken cancellationToken)
        {
            var borrow = await _context.BorrowingRecords.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ?? throw new NotFoundException<BorrowingRecord>();

            borrow.Deadline = request.Deadline ?? borrow.Deadline;
            borrow.Quantity = request.Quantity ?? borrow.Quantity;
            if(request.IsReturned)
            {
                borrow.IsReturned = request.IsReturned;
                borrow.FineForBooks = 10000 * (DateOnly.FromDateTime(DateTime.UtcNow).DayNumber - borrow.Deadline.DayNumber);
            }
            borrow.IsReturned = request.IsReturned;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BorrowingRecordsViewModel>(borrow);
        }
    }
}
