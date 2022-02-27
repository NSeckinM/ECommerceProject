﻿using ApplicationCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity
    {

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        //Navigation Props
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Picture> Pictures { get; set; }

    }
}