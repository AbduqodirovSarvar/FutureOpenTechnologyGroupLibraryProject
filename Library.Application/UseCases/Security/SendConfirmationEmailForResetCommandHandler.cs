using Library.Application.Abstractions;
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
    public class SendConfirmationEmailForResetCommandHandler : IRequestHandler<SendConfirmationEmailForResetCommand>
    {
        private readonly IAppDbContext _context;
        private readonly ILogger<SendConfirmationEmailForResetCommandHandler> _logger;
        public SendConfirmationEmailForResetCommandHandler(
            IAppDbContext appDbContext,
            ILogger<SendConfirmationEmailForResetCommandHandler> logger
            )
        {
            _context = appDbContext;
            _logger = logger;
        }
        public async Task Handle(SendConfirmationEmailForResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            _logger.LogInformation("not implemented");
        }
    }
}
