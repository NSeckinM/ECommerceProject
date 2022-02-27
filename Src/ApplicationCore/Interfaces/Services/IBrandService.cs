using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IBrandService
    {
        Task AddBrand(string brandName);

        Task DeleteBrand(int brandId);

        Task<List<Brand>> GetAllBrands();

    }
}
