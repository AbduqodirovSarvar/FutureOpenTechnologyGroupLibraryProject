using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Security
{
    public class AuthSendConfirmationEmailForResetCommand : IRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
