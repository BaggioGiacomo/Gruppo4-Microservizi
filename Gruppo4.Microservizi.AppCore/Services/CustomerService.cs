using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {

        }

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task DeleteCustomer(int id)
        {
            await _customerRepository.DeleteCustomer(id);
        }

        public async Task<CustomerContrib> GetCustomerById(int id)
        {
            return await _customerRepository.GetCustomerById(id);
        }

        public async Task InsertCustomer(CustomerContrib customer)
        {
            await _customerRepository.InsertCustomer(customer);
        }

        public Task UpdateCustomer(CustomerContrib customer)
        {
            throw new NotImplementedException();
        }

        Task<CustomerContrib> ICustomerService.GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
