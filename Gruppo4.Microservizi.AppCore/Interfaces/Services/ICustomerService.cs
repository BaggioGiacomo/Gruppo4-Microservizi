using Gruppo4.Microservizi.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task InsertCustomer(Customer customer);
        public Task UpdateCustomer(Customer customer);
        public Task<Customer> GetCustomerById(int id);
        public Task DeleteCustomer(int id);

    }
}
