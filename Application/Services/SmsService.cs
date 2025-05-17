using Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SmsService:ISmsService
    {
        private readonly ILogger<SmsService> _logger;

        public SmsService(ILogger<SmsService> logger)
        {
            _logger = logger;
        }

        public async Task SendVerificationSms(string phoneNumber, string code)
        {
            // In a real application, implement actual SMS sending logic
            _logger.LogInformation($"Sending verification code {code} to {phoneNumber}");
            await Task.Delay(100); // Simulate SMS sending
        }
    }
}
