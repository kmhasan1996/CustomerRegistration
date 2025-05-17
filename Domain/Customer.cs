using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(12)]
        public string ICNumber {  get; set; }    

        [Required, EmailAddress, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string MobileNo { get; set; }

        [MaxLength(6)]
        public string EmailVerificationCode { get; set; }
        public bool IsEmailVerified { get; set; } = false;

        [MaxLength(6)]
        public string MobileVerificationCode { get; set; }
        public bool IsMobileVerified { get; set; } = false;

        public bool AcceptedPrivacyPolicy { get; set; } = false;
        public DateTime PolicyAcceptanceDate { get; set; } 

        [MaxLength(6)]
        public string Pin { get; set; }
        public bool IsBiometricLoginEnable { get; set; } = false;

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public DateTime? VerificationDate { get; set; }

    }
}
