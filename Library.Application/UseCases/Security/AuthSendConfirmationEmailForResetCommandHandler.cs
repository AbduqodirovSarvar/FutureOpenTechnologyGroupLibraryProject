using Library.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Application.UseCases.Security
{
    public class AuthSendConfirmationEmailForResetCommandHandler : IRequestHandler<AuthSendConfirmationEmailForResetCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ILogger<AuthSendConfirmationEmailForResetCommandHandler> _logger;
        public AuthSendConfirmationEmailForResetCommandHandler(
            IAppDbContext appDbContext,
            ILogger<AuthSendConfirmationEmailForResetCommandHandler> logger
            )
        {
            _context = appDbContext;
            _logger = logger;
        }
        public async Task Handle(AuthSendConfirmationEmailForResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            _logger.LogInformation("not implemented");
        }
    }
}
