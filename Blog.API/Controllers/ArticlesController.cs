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
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        
        [ProducesResponseType(typeof(IEnumerable<ArticleDto>),200)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _articleService.GetArticles();
            return Ok(result);
        }
    }
}
