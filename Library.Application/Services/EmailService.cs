using Library.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
