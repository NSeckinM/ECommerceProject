using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Models.BrandViewModels;
using Web.Areas.Admin.Models.CategoryViewModels;

namespace Web.Areas.Admin.Models.ProductViewModels
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public CategoryViewModel CategoryViewModel { get; set; }

        public BrandViewModel BrandViewModel { get; set; }
    }
}
