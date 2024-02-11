using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.UseCases.ToDoList.Queries.StudentToDoList
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<StudentViewModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Students
                                        .Include(x => x.StudentAddresses)
                                        .ThenInclude(x => x.Address)
                                        .Include(x => x.BorrowingRecords)
                                        .ToListAsync(cancellationToken);

            return _mapper.Map<List<StudentViewModel>>(students);
        }
    }
}
