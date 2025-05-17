using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISmsService
    {
        Task SendVerificationSms(string phoneNumber, string code);
    }
}
