﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Services.API.Models.Repository
{
    public interface IProductRepository
    {

        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> GetProductById(int productId);

        Task<ProductDto> CreateUpdateProduct(ProductDto product);

        Task<bool> DeleteProduct(int productId);
    }
}
