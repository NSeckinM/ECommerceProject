using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAsyncRepository<Product> _productRepository;

        public ProductService(ApplicationDbContext dbContext, IAsyncRepository<Product> productRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
        }
        public Task AddProduct(Product product)
        {
            Product product1 = new()
            {
                ProductName = product.ProductName,
                Description = product.Description,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                Price = product.Price,
            };
            _productRepository.AddAsync(product1);
            return Task.FromResult(product1);
        }

        public async Task DeleteProduct(int productId)
        {
            Product product = await _productRepository.GetByIdAsync(productId);
            _productRepository.DeleteAsync(product);
        }

        public Task<List<Product>> GetAllProduct()
        {
            List<Product> products = _dbContext.Products.Include(x => x.Pictures).ToList();

            return Task.FromResult(products);

            //List<Product> products = await _dbContext.Products.Include(x => x.Pictures).ToListAsync();

            //return products;
        }

        public Task<Product> GetById(int id)
        {
            Product product = _dbContext.Products.Include(x => x.Pictures).FirstOrDefault(x => x.Equals(id));
            return Task.FromResult(product);
        }

        public async Task UpdateProduct(Product product)
        {
            Product dbProduct = await _productRepository.GetByIdAsync(product.Id);

            dbProduct.ProductName = product.ProductName;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.BrandId = product.BrandId;
            _productRepository.UpdateAsync(dbProduct);
        }

        private IQueryable<Product> ApplySpecification(ISpecification<Product> spec)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_dbContext.Set<Product>().Include(x => x.Pictures), spec);
        }

        public async Task<int> CountAsync(ISpecification<Product> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<List<Product>> ListAsync(ISpecification<Product> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
    }
}
