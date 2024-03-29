﻿namespace Library.Application.Abstractions
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string email, string subject, string body);
        Task<bool> SendEmailConfirmed(string email);
        bool CheckEmailConfirmed(string email, string confirmationCode);
    }
}
