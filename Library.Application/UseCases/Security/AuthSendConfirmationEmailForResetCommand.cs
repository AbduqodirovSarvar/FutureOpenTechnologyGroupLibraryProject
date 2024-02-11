using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.Security
{
    public class AuthSendConfirmationEmailForResetCommand : IRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
