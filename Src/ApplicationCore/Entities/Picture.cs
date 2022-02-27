using ApplicationCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Picture : BaseEntity
    {

        public string PictureUri { get; set; } // dosyanın yolunu tutacağız.

        //Navigation Props
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
