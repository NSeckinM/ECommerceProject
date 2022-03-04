using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Models.PhotoViewModels
{
    public class AddPhotoViewModel
    {
        public int Id { get; set; }

        public IFormFile Photo { get; set; }
    }
}
