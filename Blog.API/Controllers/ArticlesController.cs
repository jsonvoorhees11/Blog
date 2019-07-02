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

        [ProducesResponseType(typeof(IEnumerable<ArticleDto>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _articleService.GetArticles();
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ArticleDto>), 200)]
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(string categoryId){
            var result = await _articleService.GetArticlesByCategory(categoryId);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ArticleDto>), 200)]
        [HttpGet("tag/{tagId}")]
        public async Task<IActionResult> GetByTagId(string tagId){
            var result = await _articleService.GetArticlesByTag(tagId);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ArticleDto), 200)]
        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var result = await _articleService.GetArticleBySlug(slug);
            return Ok(result);
        }
    }
}
