using API.DTOs;
using API.RequestModels;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IVerificationService _verificationService;
        private readonly ICustomerService _customerService;

        public CustomersController(
            ILogger<CustomersController> logger,
            IVerificationService verificationService,
            ICustomerService customerService)
        {
            _logger = logger;
            _verificationService = verificationService;
            _customerService = customerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCustomerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!dto.AcceptPrivacyPolicy)
            {
                return BadRequest("You must accept the privacy policy to register");
            }
           
            if (await _customerService.IsCustomerExist(dto.ICNumber))
            {
                return Conflict("Customer already registered");
            }

            var customer = new Customer
            {
                Name = dto.Name,
                ICNumber = dto.ICNumber,
                Email = dto.Email,
                MobileNo = dto.MobileNo,
                AcceptedPrivacyPolicy = dto.AcceptPrivacyPolicy,
                PolicyAcceptanceDate = DateTime.UtcNow,
                Pin =dto.Pin,//may be we need to encrypt it
                EmailVerificationCode = await _verificationService.GenerateAndSendVerificationCode(true, dto.Email),
                MobileVerificationCode = await _verificationService.GenerateAndSendVerificationCode(false, dto.MobileNo)
            };

           await _customerService.Add(customer);
           
            return Ok(new
            {
                Message = "Registration successful. Please verify your email and mobile.",
                CustomerId = customer.Id,
                RequiresVerification = true
            });
        }

        [HttpPost("biometric-login")]
        public async Task<IActionResult> BiometricLogin(Guid id, bool isEnable)
        {
            var result = await _customerService.BiometricLogin(id,isEnable);

            if (result)
            {
                if (isEnable)
                {
                    return Ok(new { Message = "Biometric login enabled successfully" });
                }
                else
                {
                    return Ok(new { Message = "Biometric login disabled successfully" });
                }
            }
            else
            {
                return NotFound("Customer not found");
            }
            
        }

        [HttpPost("send-verification")]
        public async Task<IActionResult> SendVerificationCode(VerificationRequest request)
        {
            var code = await _verificationService.GenerateAndSendVerificationCode(request.IsEmail,request.EmailOrPhone);

            return Ok(new { Message = "Verification code sent successfully" });
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyCode(VerifyCodeRequest request)
        {
            var isValid = await _verificationService.VerifyCode(
                request.EmailOrPhone,
                request.Code,
                request.IsEmail);

            if (!isValid)
            {
                return BadRequest("Invalid verification code");
            }

            var customer = await _customerService.GetById(request.CustomerId);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            if (request.IsEmail)
            {
                customer.IsEmailVerified = true;
            }
            else
            {
                customer.IsMobileVerified = true;
            }

            // If both are verified, set verification date
            if (customer.IsEmailVerified && customer.IsMobileVerified)
            {
                customer.VerificationDate = DateTime.UtcNow;
            }

            await _customerService.UpdateVerification(customer.Id, customer);

            return Ok(new
            {
                Message = "Verification successful",
                IsFullyVerified = customer.IsEmailVerified && customer.IsMobileVerified
            });
        }

        [HttpGet("privacy-policy")]
        public IActionResult GetPrivacyPolicy()
        {
            // In a real application, this would come from a database or file
            var policy = new
            {
                Title = "Privacy Policy",
                Content = "This is our privacy policy. You must read and accept this to use our services.",
                EffectiveDate = "2025-01-01",
                Version = "1.0"
            };

            return Ok(policy);
        }
    }
}
