using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Security
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public UpdateUserCommandHandler
            (IAppDbContext context,
            IMapper mapper,
            IAuthService authService
            )
        {
            _context = context;
            _mapper = mapper;
            _authService = authService;
        }
        public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ?? throw new NotFoundException<User>();

            user.FullName = request.FullName ?? user.FullName;
            user.Email = request.Email ?? user.Email;
            user.Login = request.Login ?? user.Login;
            user.PasswordHash = request.Password == null ? user.PasswordHash : _authService.GetPasswordHash(request.Password);
            user.Role = request.UserRole == null ? user.Role : Enum.TryParse(request.UserRole, out UserRole role) ? role : user.Role;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
