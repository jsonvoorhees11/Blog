using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;
namespace Blog.Services{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
    }
}
