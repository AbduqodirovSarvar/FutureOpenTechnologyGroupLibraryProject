using AutoMapper;
using Library.Application.Abstractions;
using Library.Application.Exceptions;
using Library.Application.Models.ViewModels;
using Library.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Library.Application.UseCases.Security
{
    public class AuthLoginCommandHandler : IRequestHandler<AuthLoginCommand, LoginViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IAppDbContext _context;
        private readonly ILogger<AuthLoginCommandHandler> _logger;
        private readonly IMapper _mapper;
        public AuthLoginCommandHandler(
            IAuthService authService,
            IAppDbContext context,
            ILogger<AuthLoginCommandHandler> logger,
            IMapper mapper
            )
        {
            _authService = authService;
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<LoginViewModel> Handle(AuthLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                                     .FirstOrDefaultAsync(x => x.Login == request.Login, cancellationToken)
                                     ?? throw new LoginException();

            if (!_authService.VerifyPasswordHash(request.Password, user.PasswordHash))
            {
                throw new LoginException();
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

            if (user.Role == UserRole.SuperAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, UserRole.Admin.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, UserRole.None.ToString()));
            }
            if (user.Role == UserRole.Admin)
            {
                claims.Add(new Claim(ClaimTypes.Role, UserRole.None.ToString()));
            }

            var result = new LoginViewModel(_authService.GetAccessToken(claims.ToArray()), _mapper.Map<UserViewModel>(user));

            _logger.LogInformation("An access token has been issued to the identifier ID: {Identifier}", user.Id);

            return result;
        }
    }
}
