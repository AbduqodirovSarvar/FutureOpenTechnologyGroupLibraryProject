using Library.Application.Abstractions;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Application.UseCases.Security
{
    public class AuthSendConfirmationEmailForResetCommandHandler : IRequestHandler<AuthSendConfirmationEmailForResetCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ILogger<AuthSendConfirmationEmailForResetCommandHandler> _logger;
        private readonly IEmailService _emailService;
        public AuthSendConfirmationEmailForResetCommandHandler(
            IAppDbContext appDbContext,
            ILogger<AuthSendConfirmationEmailForResetCommandHandler> logger,
            IEmailService emailService
            )
        {
            _context = appDbContext;
            _logger = logger;
            _emailService = emailService;
        }
        public async Task Handle(AuthSendConfirmationEmailForResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken) ?? throw new NotFoundException<User>();
            try
            {
                await _emailService.SendEmailConfirmed(user.Email);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error while sending mail: ", ex.Message);
            }
        }
    }
}
