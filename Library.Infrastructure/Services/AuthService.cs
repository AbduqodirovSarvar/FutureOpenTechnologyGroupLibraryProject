using Library.Application.Abstractions;
using Library.Infrastructure.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        public JWTConfiguration _configuration;
        public AuthService(IOptions<JWTConfiguration> config)
        {
            _configuration = config.Value;
        }

        public string GetAccessToken(Claim[] claims)
        {
            Claim[] jwtClaim = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, DateTime.UtcNow.ToString()),
            };

            var jwtCLaims = claims.Concat(jwtClaim);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret)),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                _configuration.ValidIssuer,
                _configuration.ValidAudience,
                jwtCLaims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public string GetPasswordHash(string password)
        {
            var salt = new byte[32];
            RandomNumberGenerator.Create().GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 20000, HashAlgorithmName.SHA256);


            byte[] hash = pbkdf2.GetBytes(32);

            byte[] hashBytes = new byte[64];

            Array.Copy(salt, 0, hashBytes, 0, 32);
            Array.Copy(hash, 0, hashBytes, 32, 32);

            var result = Convert.ToBase64String(hashBytes);
            return result;
        }

        public bool VerifyPasswordHash(string password, string paswordHash)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(paswordHash);
                byte[] salt = new byte[32];
                Array.Copy(hashBytes, 0, salt, 0, 32);

                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 20000, HashAlgorithmName.SHA256);
                byte[] hash = pbkdf2.GetBytes(32);

                for (int i = 0; i < 32; i++)
                {
                    if (hashBytes[i + 32] != hash[i])
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return true;
        }
    }
}
