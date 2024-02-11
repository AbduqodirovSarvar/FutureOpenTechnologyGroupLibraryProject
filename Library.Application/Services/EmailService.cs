using Library.Application.Abstractions;

namespace Library.Application.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string toEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
