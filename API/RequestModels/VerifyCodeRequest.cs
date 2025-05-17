namespace API.RequestModels
{
    public class VerifyCodeRequest
    {
        public Guid CustomerId { get; set; }
        public string EmailOrPhone { get; set; }
        public string Code { get; set; }
        public bool IsEmail { get; set; }
    }
}
