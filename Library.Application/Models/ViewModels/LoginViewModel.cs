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
