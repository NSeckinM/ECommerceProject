using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Specifications;
using Infrastructure.Data.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public HomeViewModelService(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }
        public async Task<HomeViewModel> GetHomeViewModelAsync(int? categoryId, int? brandId, int page)
        {
            var specProducts = new ProdutsFilterSpecification(categoryId, brandId);

            var totalItemsCount = await _productService.CountAsync(specProducts);

            var totalPagesCount = (int)Math.Ceiling((decimal)totalItemsCount / Constants.ITEMS_PER_PAGE);

            var specPaginatedProducts = new ProductsFilterPaginatedSpecification(categoryId, brandId,
                (page - 1) * Constants.ITEMS_PER_PAGE, Constants.ITEMS_PER_PAGE);


            var products = await _productService.ListAsync(specPaginatedProducts);

            var vm = new HomeViewModel()
            {
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Pictures = p.Pictures,
                    PictureUri = p.Pictures[0].PictureUri,
                    Price = p.Price

                }).ToList(),

                Categories = await GetCategoriesAsync(),
                Brands = await GetBrandsAsync(),
                CategoryId = categoryId,
                BrandId = brandId,

                paginationInfo = new PaginationInfoViewModel()
                {
                    Page = page,
                    TotalItems = totalItemsCount,
                    TotalPages = totalPagesCount,
                    ItemOnPage = products.Count,
                    HasPrevious = page > 1,
                    HasNext = page < totalPagesCount
                }
            };

            return vm;
        }

        private async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
        {
            var brands = await _brandService.GetAllBrands();
            return brands.Select(b => new SelectListItem(b.BrandName, b.Id.ToString()));
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategory();
            return categories.Select(c => new SelectListItem(c.CategoryName, c.Id.ToString()));
        }


        public async Task<ProductViewModelForModal> GetProductForModalAsync(int id)
        {
            Product product =await _productService.GetById(id);

            ProductViewModelForModal productView = new()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                PictureUri = product.Pictures[0].PictureUri,
                Pictures = product.Pictures,

            };

            return productView;
        }


    }
}
