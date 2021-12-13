using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task InsertCustomer(CustomerContrib customer);
        public Task UpdateCustomer(CustomerContrib customer);
        public Task<CustomerContrib> GetCustomerById(int id);
        public Task DeleteCustomer(int id);

    }
}
