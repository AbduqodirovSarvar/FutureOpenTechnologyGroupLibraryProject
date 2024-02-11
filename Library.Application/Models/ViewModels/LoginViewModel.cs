using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.ViewModels
{
    public record LoginViewModel
    {
        public LoginViewModel(string accessToken, UserViewModel user)
        {
            AccessToken = accessToken;
            User = user;
        }
        public string AccessToken { get; init; } = null!;
        public UserViewModel User { get; init; } = null!;
    }
}
