﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class ProductViewModelForModal
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string Description { get; set; }
        public string PictureUri { get; set; }
        public decimal Price { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
