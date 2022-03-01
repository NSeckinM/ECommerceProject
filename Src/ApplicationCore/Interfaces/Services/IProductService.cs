using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> GetById(int id);
        Task<List<Product>> GetAllProduct();
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
        Task<int> CountAsync(ISpecification<Product> spec);
        Task<List<Product>> ListAsync(ISpecification<Product> spec);


    }
}
