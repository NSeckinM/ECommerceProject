using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeViewModelService _homeViewModelService;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IHomeViewModelService homeViewModelService,IProductService productService)
        {
            _logger = logger;
            _homeViewModelService = homeViewModelService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(int? categoryId, int? brandId, int page = 1)
        {
            return View(await _homeViewModelService.GetHomeViewModelAsync(categoryId, brandId, page));
        }

        [HttpPost]
        public async Task<IActionResult> ProductDetail(int id)
        {
            ProductViewModelForModal Pvm = await _homeViewModelService.GetProductForModalAsync(id);
            return View(Pvm);
        }
      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
