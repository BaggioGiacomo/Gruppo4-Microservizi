﻿using Gruppo4.Microservizi.AppCore.Models.ModelContrib;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Data
{
    public interface IProductRepository
    {
        public Task RefillQuantity(int id, int quantity);
        public Task<int> GetStockQuantity(int id);
        public Task<bool> HasEnoughStocked(int id, int quantity);
        public Task DeleteProduct(int id);
        public Task InsertProduct(ProductContrib product);
        public Task UpdateProduct(ProductContrib product);
        public Task<ProductContrib> GetProductById(int id);

    }
}
