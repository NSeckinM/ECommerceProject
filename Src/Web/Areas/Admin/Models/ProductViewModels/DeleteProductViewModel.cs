using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Models.ProductViewModels
{
    public class DeleteProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }
    }
}
