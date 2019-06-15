using System;
using System.Collections.Generic;
using Blog.Models;
namespace Blog.Services{
    public interface IArticleService
    {
        IEnumerable<ArticleDto> GetArticles();
        ArticleDto GetArticleById(string id);
        ArticleDto UpdateArticleById(ArticleDto updatedArticle);
        ArticleDto CreateArticle(ArticleDto newArticle);
        string DeleteArticle(string articleID);
    }
}
