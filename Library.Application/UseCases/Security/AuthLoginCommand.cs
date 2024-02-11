using Library.Application.Models.ViewModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.Security
{
    public class AuthLoginCommand : IRequest<LoginViewModel>
    {
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
