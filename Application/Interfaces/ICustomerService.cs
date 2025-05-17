using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Add(Customer customer);
        Task<bool> BiometricLogin(Guid id, bool isEnable);
        Task<Customer> UpdateVerification(Guid id, Customer customer);
        Task<Customer> GetById(Guid id);
        Task<bool> IsCustomerExist(string icNumber);
    }
}
