using ApplicationCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }

        //Navigation Props
        public List<Product> Products { get; set; }

    }
}
