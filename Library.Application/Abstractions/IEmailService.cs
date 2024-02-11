namespace Library.Application.Abstractions
{
    public interface IEmailService
    {
        bool SendEmail(string toEmail, string subject, string body);
    }
}
