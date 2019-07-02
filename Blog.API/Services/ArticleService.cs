using System;
using System.Collections.Generic;
using Blog.Models;
using Blog.DataAccess.Repositories;
using Blog.DataAccess.Entities;
using Blog.Mappers;
using Blog.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class ArticleService : IArticleService
    {
        private readonly BlogDbContext _dbContext;
        public ArticleService()
        {

        }
        public ArticleService(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ArticleDto CreateArticle(ArticleDto newArticle)
        {
            throw new NotImplementedException();
        }

        public string DeleteArticle(string articleID)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleDto> GetArticleBySlug(string slug)
        {
            var articlesQuery = GetArticlesQuery();
            var articleEntity = articlesQuery.First(a=>a.Slug==slug);
            var result = MapArticleToDto(articleEntity);
            return result;
        }

        public async Task<IEnumerable<ArticleDto>> GetArticles()
        {
            var articlesQuery = GetArticlesQuery();
            var articleEntities = articlesQuery.ToList();
            var result = new List<ArticleDto>();
            foreach (var entity in articleEntities)
            {
                ArticleDto article = MapArticleToDto(entity);
                result.Add(article);
            }
            return result;
        }

        public async Task<IEnumerable<ArticleDto>> GetArticlesByCategory(string categoryId){
            var articlesQuery = GetArticlesQuery();
            var articleEntities = articlesQuery
                                    .Where(a=>a.ArticleCategories.Select(ac=>ac.CategoryId).Contains(categoryId))
                                    .ToList();
            var result = new List<ArticleDto>();
            foreach (var entity in articleEntities)
            {
                ArticleDto article = MapArticleToDto(entity);
                result.Add(article);
            }
            return result;
        }

        public async Task<IEnumerable<ArticleDto>> GetArticlesByTag(string tagId){
            var articlesQuery = GetArticlesQuery();
            var articleEntities = articlesQuery
                                    .Where(a=>a.ArticleTags.Select(at=>at.TagId).Contains(tagId))
                                    .ToList();
            
            var result = new List<ArticleDto>();
            foreach (var entity in articleEntities)
            {
                ArticleDto article = MapArticleToDto(entity);
                result.Add(article);
            }
            return result;

        }

        public async Task<ArticleDto> UpdateArticleById(ArticleDto updatedArticle)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Article> GetArticlesQuery(){
            return _dbContext.Articles
                            .Include(a => a.Author)
                            .Include(a => a.ArticleTags).ThenInclude(t => t.Tag)
                            .Include(a => a.ArticleCategories).ThenInclude(c => c.Category);
        }
        private ArticleDto MapArticleToDto(Article entity)
        {
            ArticleDto result = new ArticleDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                ThumbnailImageUrl = entity.ThumbnailImageUrl,
                Recap = entity.Recap,
                Content = entity.Content,
                Author = new UserDto
                {
                    Id = entity.Author.Id,
                    Email = entity.Author.Email,
                    CreatedDate = entity.Author.CreatedDate,
                    WrittenArticles = null
                },
                Tags = entity.ArticleTags.Select(a => a.Tag)
                                        .Select(t => new TagDto
                                        {
                                            Id = t.Id,
                                            Alias = t.Alias
                                        }),
                Categories = entity.ArticleCategories.Select(a => a.Category)
                                        .Select(t => new CategoryDto
                                        {
                                            Id = t.Id,
                                            Description = t.Description,
                                            ParentId = t.ParentId,
                                        }),
                //Load comment later
                Comments = new List<CommentDto>()
            };
            return result;
        }
    }
}
