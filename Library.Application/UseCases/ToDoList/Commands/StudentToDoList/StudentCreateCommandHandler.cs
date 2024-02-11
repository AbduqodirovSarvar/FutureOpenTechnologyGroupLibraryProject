using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.UseCases.ToDoList.Commands.StudentToDoList
{
    public class StudentCreateCommandHandler : IRequestHandler<StudentCreateCommand, StudentViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public StudentCreateCommandHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<StudentViewModel> Handle(StudentCreateCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                                        .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken)
                                        ?? (await _context.Students.AddAsync(new Student(request.FullName, request.Email), cancellationToken)).Entity;

            var address = await _mediator.Send(new StudentAddressCreateCommand()
            {
                StudentId = student.Id,
                CountryName = request.CountryName,
                CityName = request.CityName,
                RegionName = request.RegionName,
                Block = request.Block,
                Street = request.Street,
                HomeNumber = request.HomeNumber,
                ApartmentNumber = request.ApartmentNumber
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<StudentViewModel>(student);
        }
    }
}
