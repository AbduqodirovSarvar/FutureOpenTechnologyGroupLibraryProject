using Library.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Library.Application.Services
{
    public class CurrentUser : ICurrentUser
    {
        public CurrentUser(IHttpContextAccessor _contextAccessor)
        {
            var httpContext = _contextAccessor.HttpContext;
            var userClaims = httpContext?.User.Claims;
            var idClaim = userClaims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            //var roleClaim = userClaims?.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            if (idClaim != null && Guid.TryParse(idClaim.Value, out Guid userId))
            {
                UserId = userId;
            }
            /*if(roleClaim != null && Enum.TryParse(roleClaim.Value, out UserRole role))
            {
                UserRole = role;
            }*/

        }
        //public UserRole UserRole { get; set; }
        public Guid UserId { get; set; }

    }
}
