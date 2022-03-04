using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Areas.Admin.Models.BrandViewModels;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<ActionResult> Index()
        {
            List<Brand> brands = await _brandService.GetAllBrands();

            BrandViewModel brandVm = new()
            {
                Brands = brands
            };

            return View(brandVm);
        }

        public ActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBrand(CreateBrandViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _brandService.AddBrand(vm.BrandName);
                return RedirectToAction("Index", "Brand");
            }
            return View();
        }


        public async Task<ActionResult> EditBrand(int id)
        {
            Brand brand = await _brandService.GetByIdBrand(id);
            EditBrandViewModel vm = new()
            {
                Id = brand.Id,
                BrandName = brand.BrandName
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditBrand(EditBrandViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Brand brand = await _brandService.GetByIdBrand(vm.Id);
                brand.BrandName = vm.BrandName;
                await _brandService.Update(brand);
                return RedirectToAction("Index", "Brand");

            }
            return View();
        }

        public async Task<ActionResult> DeleteBrand(int id)
        {
            Brand brand =await _brandService.GetByIdBrand(id);
            if (brand == null)
            {
                return NotFound();
            }
            DeleteBrandViewModel deleteBrandVm = new()
            {
                Id = brand.Id,
                BrandName = brand.BrandName
            };

            return View(deleteBrandVm);
        }

        // POST: BrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBrand(DeleteBrandViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _brandService.DeleteBrand(vm.Id);
                return RedirectToAction("Index", "Brand");
            }
            return View();
        }
    }
}
