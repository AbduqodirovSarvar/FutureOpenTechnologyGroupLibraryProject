using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Security
{
    public class AuthRegisterCommandHandler : IRequestHandler<AuthRegisterCommand, UserViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthRegisterCommandHandler> _logger;
        private readonly IAuthService _authService;

        public AuthRegisterCommandHandler(
            IAppDbContext appDbContext,
            ICurrentUser currentUser,
            IMapper mapper,
            ILogger<AuthRegisterCommandHandler> logger,
            IAuthService authService
            )
        {
            _context = appDbContext;
            _currentUser = currentUser;
            _mapper = mapper;
            _logger = logger;
            _authService = authService;
        }
        public async Task<UserViewModel> Handle(AuthRegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                                    .FirstOrDefaultAsync(x => x.Email == request.Email && x.Login == request.Email, cancellationToken);

            if( user != null )
            {
                throw new AlreadyExistsException<User>();
            }

            user = new User(
                request.FullName,
                request.Email,
                request.Login,
                _authService.GetPasswordHash(request.Password)
                )
            {
                CreatedById = _currentUser.UserId
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("User created");
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
