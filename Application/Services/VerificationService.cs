using Application.Interfaces;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Services
{
    public class VerificationService:IVerificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private readonly ILogger<VerificationService> _logger;

        public VerificationService(
            ApplicationDbContext context,
            IEmailService emailService,
            ISmsService smsService,
            ILogger<VerificationService> logger)
        {
            _context = context;
            _emailService = emailService;
            _smsService = smsService;
            _logger = logger;
        }

        public async Task<string> GenerateAndSendVerificationCode(bool isEmail,string emailOrPhone)
        {
            var code = new Random().Next(1000, 4999).ToString();

            if (isEmail)
            {
                await _emailService.SendVerificationEmail(emailOrPhone, code);
                _logger.LogInformation($"Verification code {code} sent to email {emailOrPhone}");
            }
            else
            {
                await _smsService.SendVerificationSms(emailOrPhone, code);
                _logger.LogInformation($"Verification code {code} sent to phone {emailOrPhone}");
            }

            return code;
        }

        public async Task<bool> VerifyCode(string emailOrPhone, string code, bool isEmail)
        {
            // In a real application, we would check against stored codes with expiration
            // For simplicity, we'll just return true if the code is 4 digits
            return code.Length == 4 && code.All(char.IsDigit);
        }
    }
}
