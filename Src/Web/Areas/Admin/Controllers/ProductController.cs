using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Web.Areas.Admin.Models.BrandViewModels;
using Web.Areas.Admin.Models.CategoryViewModels;
using Web.Areas.Admin.Models.PhotoViewModels;
using Web.Areas.Admin.Models.ProductViewModels;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IPictureService _pictureService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService, IPictureService pictureService, IWebHostEnvironment env)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _pictureService = pictureService;
            _env = env;
        }
        public async Task<ActionResult> Index()
        {
            List<Product> products = await _productService.GetAllProduct();
            DashboardProductViewModal productVm = new()
            {
                Products = products
            };
            return View(productVm);
        }



        public async Task<ActionResult> CreateProduct()
        {
            List<Category> categories = await _categoryService.GetAllCategory();
            List<Brand> brands = await _brandService.GetAllBrands();

            CategoryViewModel categoryVm = new() { Categories = categories };
            BrandViewModel brandVm = new() { Brands = brands };

            CreateProductViewModel createProductVm = new() { CategoryViewModel = categoryVm, BrandViewModel = brandVm };

            return View(createProductVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(CreateProductViewModel vm)
        {
            Product product = new()
            {
                ProductName = vm.ProductName,
                Description = vm.Description,
                Price = vm.Price,
                CategoryId = vm.CategoryId,
                BrandId = vm.BrandId,

            };
            Picture defaultPic = new() { PictureUri = "empty-img.jpg", Product = product };

            _productService.AddProduct(product);
            _pictureService.AddPicture(defaultPic);
            return RedirectToAction("Index", "Product");
        }

        public async Task<ActionResult> EditProduct(int id)
        {
            Product product = await _productService.GetById(id);

            List<Category> categories = await _categoryService.GetAllCategory();
            List<Brand> brands = await _brandService.GetAllBrands();

            CategoryViewModel categoryVm = new() { Categories = categories };
            BrandViewModel brandVm = new() { Brands = brands };

            EditProductViewModel editProductVm = new()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,
                BrandId = product.BrandId,
                BrandName = product.Brand.BrandName,
                CategoryViewModel = categoryVm,
                BrandViewModel = brandVm
            };

            return View(editProductVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProduct(EditProductViewModel vm)
        {
            Product product = await _productService.GetById(vm.Id);

            //TODO: Zaman kalırsa Automapper ekle
            product.ProductName = vm.ProductName;
            product.Description = vm.Description;
            product.Price = vm.Price;
            product.CategoryId = vm.CategoryId;
            product.BrandId = vm.BrandId;

            await _productService.UpdateProduct(product);

            return RedirectToAction("Index", "Product");

        }


        public async Task<ActionResult> DeleteProduct(int id)
        {
            Product product = await _productService.GetById(id);

            DeleteProductViewModel deleteProductVm = new()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                CategoryName = product.Category.CategoryName,
                BrandName = product.Brand.BrandName
            };
            return View(deleteProductVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteProduct(DeleteProductViewModel vm)
        {
            await _productService.DeleteProduct(vm.Id);
            return RedirectToAction("Index", "Product");
        }


        public ActionResult AddPhoto(int id)
        {
            AddPhotoViewModel AddPhotoVm = new() { Id = id };
            return View(AddPhotoVm);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoto(AddPhotoViewModel AddPhotovm)
        {
            IFormFile photo = AddPhotovm.Photo;
            if (photo == null || photo.Length == 0)
                ModelState.AddModelError("photo", "yüklenecek resim dosyası bulunamadı");

            else if (!photo.ContentType.StartsWith("image/"))
                ModelState.AddModelError("photo", "Lütfen bir resim dosyası seçin");

            //izin verilen en büyük dosya boyutu 1mb
            else if (photo.Length > 1 * 1000 * 1000)
                ModelState.AddModelError("photo", "maksimum dosya boyutu 1 mb'dır");


            if (ModelState.IsValid)
            {
                string uzanti = Path.GetExtension(photo.FileName);
                string yeniDosyaAd = Guid.NewGuid() + uzanti; // doaya adını diğer gelecek fotolarla aynı olup karışmaması için uniq yaptım.
                string kayityolu = Path.Combine(_env.WebRootPath, "images/products", yeniDosyaAd);

                using (FileStream fs = System.IO.File.Create(kayityolu))
                {
                    photo.CopyTo(fs);
                }

                Product product = await _productService.GetById(AddPhotovm.Id);
                if (product.Pictures.Count == 1 && product.Pictures[0].PictureUri == "empty-img.jpg")
                {
                    product.Pictures.Remove(product.Pictures[0]);
                }

                Picture picture = new Picture()
                {
                    PictureUri = yeniDosyaAd,
                    ProductId = product.Id,
                    Product = product
                };

                await _pictureService.AddPicture(picture);
                return RedirectToAction("Index", "Product");
            }
            return View();
        }


        public async Task<ActionResult> DeletePhoto(int id)
        {
            Product product = await _productService.GetById(id);

            DeletePhotoViewModel deletePhotoVm = new() { Pictures = product.Pictures };

            return View(deletePhotoVm);

        }

        // [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePhotoPost(int id)
        {
            Picture picture = await _pictureService.GetByIdPicture(id);

            var photoPath = Path.Combine(_env.WebRootPath, "images/products", picture.PictureUri);
            if (System.IO.File.Exists(photoPath))
            {
                System.IO.File.Delete(photoPath);
            }

            await _pictureService.DeletePicture(id);

            return RedirectToAction("Index", "Product");

        }



    }
}
