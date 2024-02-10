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
    public class BorrowingRecordCreateCommandHandler : IRequestHandler<BorrowingRecordCreateCommand, BorrowingRecordsViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public BorrowingRecordCreateCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BorrowingRecordsViewModel> Handle(BorrowingRecordCreateCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == request.StudentId, cancellationToken) ?? throw new NotFoundException<User>();
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken) ?? throw new NotFoundException<Book>();

            var borrow = (await _context.BorrowingRecords.AddAsync(new BorrowingRecord(student.Id, book.Id, request.DeadLine, request.Quantity), cancellationToken)).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BorrowingRecordsViewModel>(borrow);
        }
    }
}
