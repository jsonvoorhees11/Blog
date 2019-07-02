using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace SourceCodes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [ProducesResponseType(typeof(IEnumerable<ArticleDto>),200)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetCategories();
            return Ok(result);
        }

        
    }
}
