using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVerificationService
    {
        Task<string> GenerateAndSendVerificationCode(bool isEmail,string emailOrPhone);
        Task<bool> VerifyCode(string emailOrPhone, string code, bool isEmail);
    }
}
