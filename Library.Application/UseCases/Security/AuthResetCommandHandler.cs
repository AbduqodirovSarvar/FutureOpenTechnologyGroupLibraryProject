using Library.Application.Abstractions;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.UseCases.Security
{
    public class AuthResetCommandHandler : IRequestHandler<AuthResetCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;

        public AuthResetCommandHandler(IAppDbContext context, IEmailService emailService, IAuthService authService)
        {
            _context = context;
            _emailService = emailService;
            _authService = authService;
        }
        public async Task<bool> Handle(AuthResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken) ?? throw new NotFoundException<User>();

            if (_emailService.CheckEmailConfirmed(user.Email, request.ConfirmationCode.ToString()) && request.NewPassword == request.ConfirmNewPassword)
            {
                user.PasswordHash = _authService.GetPasswordHash(request.NewPassword);
                return (await _context.SaveChangesAsync(cancellationToken)) > 0;
            }
            return false;
        }
    }
}
