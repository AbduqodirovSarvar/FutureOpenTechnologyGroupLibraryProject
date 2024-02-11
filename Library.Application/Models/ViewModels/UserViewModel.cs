namespace Library.Application.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }

        public UserViewModel()
        {

        }
    }
}
