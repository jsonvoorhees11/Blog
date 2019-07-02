using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;
namespace Blog.Services{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleDto>> GetArticles();
        Task<IEnumerable<ArticleDto>> GetArticlesByCategory(string categoryId);
        Task<IEnumerable<ArticleDto>> GetArticlesByTag(string tagID);
        Task<ArticleDto> GetArticleBySlug(string slug);
        Task<ArticleDto> UpdateArticleById(ArticleDto updatedArticle);
        ArticleDto CreateArticle(ArticleDto newArticle);
        string DeleteArticle(string articleID);
    }
}
