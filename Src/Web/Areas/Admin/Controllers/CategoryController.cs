using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Areas.Admin.Models.CategoryViewModels;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")] [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ActionResult> Index()
        {
            List<Category> categories = await _categoryService.GetAllCategory();

            CategoryViewModel categoryVm = new()
            {
                Categories = categories
            };
            return View(categoryVm);
        }
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCategory(CreateCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddCategory(vm.CategoryName);

                return RedirectToAction("Index", "Category");
            }
            return View();

        }

        public async Task<ActionResult> EditCategory(int id)
        {
            Category category =await _categoryService.GetByIdCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            EditCategoryViewModel editCategoryVm = new()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
            return View(editCategoryVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCategory(EditCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Category category = await _categoryService.GetByIdCategory(vm.Id);
                category.CategoryName = vm.CategoryName;
                await _categoryService.Update(category);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

       
        public async Task<ActionResult> DeleteCategory(int id)
        {

            Category category = await _categoryService.GetByIdCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            DeleteCategoryViewModel deleteCategoryVm = new()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
            return View(deleteCategoryVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(DeleteCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _categoryService.DeleteCategory(vm.Id);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
