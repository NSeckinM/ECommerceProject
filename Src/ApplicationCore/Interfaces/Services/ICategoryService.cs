using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<Category> GetByIdCategory(int id);
        Task<List<Category>> GetAllCategory();
        Task AddCategory(string categoryName);
        Task DeleteCategory(int categoryId);
        Task Update(Category category);

    }
}
