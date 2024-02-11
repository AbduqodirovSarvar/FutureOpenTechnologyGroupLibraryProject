using System.Security.Claims;

namespace Library.Application.Abstractions
{
    public interface IAuthService
    {
        string GetAccessToken(Claim[] claims);
        string GetPasswordHash(string password);
        bool VerifyPasswordHash(string password, string paswordHash);
    }
}
