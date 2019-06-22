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
        public ArticleService(){

        }
        public ArticleService(BlogDbContext dbContext){
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

        public ArticleDto GetArticleById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArticleDto>> GetArticles()
        {
            var articleEntities = _dbContext.Articles
                                    .Include(a => a.Author)
                                    .Include(a=>a.ArticleTags).ThenInclude(t=>t.Tag)
                                    .Include(a=>a.ArticleCategories).ThenInclude(c=>c.Category)
                                    .ToList();
            var result = new List<ArticleDto>();
            foreach (var item in articleEntities)
            {
                ArticleDto article = new ArticleDto{
                    Id = item.Id,
                    Title = item.Title,
                    Slug = item.Slug,
                    ThumbnailImageUrl = item.ThumbnailImageUrl,
                    Recap = item.Recap,
                    Content = item.Content,
                    Author = new UserDto{
                        Id = item.Author.Id,
                        Email = item.Author.Email,
                        CreatedDate = item.Author.CreatedDate,
                        WrittenArticles = null
                    },
                    Tags = item.ArticleTags.Select(a=>a.Tag)
                            .Select(t=> new TagDto{
                                Id = t.Id,
                                Alias = t.Alias
                            }),
                    Categories = item.ArticleCategories.Select(a=>a.Category)
                            .Select(t=>new CategoryDto{
                                Id = t.Id,
                                Description = t.Description,
                                ParentId = t.ParentId,
                            }),
                    //Load comment later
                    Comments = new List<CommentDto>()
                };
                result.Add(article);
            }
            return result;
        }

        public ArticleDto UpdateArticleById(ArticleDto updatedArticle)
        {
            throw new NotImplementedException();
        }
    }
}
