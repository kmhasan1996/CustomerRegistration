using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterCustomerDto
    {
       
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(12)]
        public string ICNumber { get; set; }

        [Required, EmailAddress, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string MobileNo { get; set; }

        public bool AcceptPrivacyPolicy { get; set; }

        [Required, MinLength(6), MaxLength(6)]
        public string Pin { get; set; }

        public bool IsBiometricLoginEnable { get; set; }
    }
}
