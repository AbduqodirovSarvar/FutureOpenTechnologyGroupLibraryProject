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

namespace Library.Application.UseCases.ToDoList.Queries.StudentToDoList
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetStudentByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StudentViewModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                                        .Include(x => x.StudentAddresses)
                                        .ThenInclude(x => x.Address)
                                        .Include(x => x.BorrowingRecords)
                                        .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                        ?? throw new NotFoundException<Student>();

            return _mapper.Map<StudentViewModel>(student);
        }
    }
}
