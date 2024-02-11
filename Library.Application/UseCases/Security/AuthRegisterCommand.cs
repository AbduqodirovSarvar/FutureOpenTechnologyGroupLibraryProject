using Library.Application.Models.ViewModels;
using MediatR;

namespace Library.Application.UseCases.Security
{
    public class AuthRegisterCommand : IRequest<UserViewModel>
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
