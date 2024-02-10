using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Security
{
    public class UpdateUserCommand : IRequest<UserViewModel>
    {
        [Required]
        public Guid Id { get; set; } = default!;
        public string? FullName { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Login { get; set; } = null;
        public string? Password { get; set; } = null;
        public string? UserRole { get; set; } = null;
    }
}
