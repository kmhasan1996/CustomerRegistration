using Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmailService: IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task SendVerificationEmail(string email, string code)
        {
            // In a real application, implement actual email sending logic
            // Using SendGrid, MailKit, etc.
            _logger.LogInformation($"Sending verification code {code} to {email}");
            await Task.Delay(100); // Simulate email sending
        }
    }
}
