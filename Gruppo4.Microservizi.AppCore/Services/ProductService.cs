using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<int> GetStockQuantity(int id)
        {
            return await _productRepository.GetStockQuantity(id);
        }

        public async Task<bool> HasEnoughStocked(int id, int quantity)
        {
            return await _productRepository.HasEnoughStocked(id, quantity);
        }

        public async Task InsertProduct(Product product)
        {
            await _productRepository.InsertProduct(product);
        }

        public async Task RefillQuantity(int id, int quantity)
        {
            await _productRepository.RefillQuantity(id, quantity);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.UpdateProduct(product);
        }
    }
}
