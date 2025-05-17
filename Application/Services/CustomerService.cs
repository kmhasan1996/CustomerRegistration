using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Add(Customer customer)
        {
           
            _context.Customers.Add(customer);
            await  _context.SaveChangesAsync();
            return customer;
        }
        public async Task<bool> BiometricLogin(Guid id,bool isEnable)
        {
            var customer = await this.GetById(id);
            customer.IsBiometricLoginEnable = isEnable;
            _context.Entry(customer).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Customer> UpdateVerification(Guid id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await  _context.SaveChangesAsync();
            return customer;
        }
       
        public async Task<Customer> GetById(Guid Id)
        {
            return await _context.Customers.FindAsync(Id);
        }

        public async Task<bool> IsCustomerExist(string ICNumber)
        {
            return await _context.Customers.AnyAsync(x=>x.ICNumber == ICNumber);
        }

       
    }
}
