using Library.Application.Abstractions;
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.DB.Configurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IAuthService _authService;
        public UserTypeConfiguration(IAuthService authService)
        {
            _authService = authService;
        }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Login).IsUnique();
            builder.HasData(new User("SuperAdmin", "superadmin@gmail.com", "superadmin", _authService.GetPasswordHash("password"), UserRole.SuperAdmin));
        }
    }
}
