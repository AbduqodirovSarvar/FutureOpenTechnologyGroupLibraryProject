using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.BorrowingToDoList
{
    public class GetBorrowsByFilterQueryHandler : IRequestHandler<GetBorrowsByFilterQuery, List<BorrowingRecordsViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetBorrowsByFilterQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BorrowingRecordsViewModel>> Handle(GetBorrowsByFilterQuery request, CancellationToken cancellationToken)
        {
            var borrows = await _context.BorrowingRecords
                                        .Include(x => x.Book)
                                        .Include(x => x.Student)
                                        .ToListAsync(cancellationToken);

            return _mapper.Map<List<BorrowingRecordsViewModel>>(borrows);
        }
    }
}
