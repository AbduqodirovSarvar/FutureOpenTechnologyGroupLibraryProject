using Library.Application.Abstractions;
using Library.Domain.Enums;
using Library.Infrastructure.DB;
using Library.Infrastructure.Models;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public static class DepencyInjection
    {
        public static void InfrastructureLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IAuthService, AuthService>();

            raw.SetProvider(imp: new SQLite3Provider_e_sqlite3());
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("SQLiteConnection"));
            });
            Batteries.Init();

            services.Configure<JWTConfiguration>(configuration.GetSection("JWTConfiguration"));

            var secretWord = configuration["JWTConfiguration:Secret"] ?? "JWTConfiguration:Secret";

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = configuration["JWTConfiguration:ValidAudience"],
                        ValidIssuer = configuration["JWTConfiguration:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretWord))
                    };
                });
            services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRole.Admin.ToString());
                });

                option.AddPolicy("SuperAdminActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRole.SuperAdmin.ToString());
                });
            });
            services.AddAuthorization();
        }

    }
}
