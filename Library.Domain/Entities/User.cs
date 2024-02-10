using Library.Domain.Abstractions;
using Library.Domain.Enums;

namespace Library.Domain.Entities
{
    public sealed class User : PersonBase
    {
        public User() : base() { }

        public User(string fullName, string email, string login, string passwordHash)
           : base(fullName, email)
        {
            Login = login;
            PasswordHash = passwordHash;
        }

        public User(string fullName, string email, string login, string passwordHash, string userRoleName)
            : base(fullName, email)
        {
            Login = login;
            PasswordHash = passwordHash;
            Role = (UserRole)Enum.Parse(typeof(UserRole), userRoleName);
        }

        public User(string fullName, string email, string login, string passwordHash, UserRole role)
           : base(fullName, email)
        {
            Login = login;
            PasswordHash = passwordHash;
            Role = role;
        }
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; } = UserRole.None;
    }
}
