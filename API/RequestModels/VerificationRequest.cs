namespace API.RequestModels
{
    public class VerificationRequest
    {
        public Guid CustomerId {  get; set; }
        public string EmailOrPhone { get; set; }
        public bool IsEmail { get; set; }
    }
}
