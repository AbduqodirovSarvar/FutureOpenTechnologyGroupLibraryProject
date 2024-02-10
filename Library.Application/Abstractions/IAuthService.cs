using Library.Application.Models.Dtos;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Abstractions
{
    public interface IAuthService
    {
        string GetAccessToken(Claim[] claims);
        string GetPasswordHash(string key);
        bool VerifyPasswordHash(string password, string paswordHash);
    }
}
