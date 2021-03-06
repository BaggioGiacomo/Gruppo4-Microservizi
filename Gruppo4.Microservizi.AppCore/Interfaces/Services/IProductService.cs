using Gruppo4.Microservizi.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Services
{
    public interface IProductService
    {
        public Task RefillQuantity(int id, int quantity);
        public Task<int> GetStockQuantity(int id);
        public Task<bool> HasEnoughStocked(int id, int quantity);
        public Task DeleteProduct(int id);
        public Task InsertProduct(Product product);
        public Task UpdateProduct(Product product);
    }
}
