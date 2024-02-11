using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.Security
{
    public class AuthResetCommand : IRequest<bool>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string NewPassword { get; set; } = null!;
        [Required]
        public string ConfirmNewPassword { get; set; } = null!;
        [Required]
        public int ConfirmationCode { get; set; }
    }
}
