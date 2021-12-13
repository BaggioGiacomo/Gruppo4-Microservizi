using Gruppo4.Microservizi.AppCore.Models.ModelContrib;

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
