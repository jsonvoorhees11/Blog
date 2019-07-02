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
    public class CategoryService : ICategoryService
    {
        private readonly BlogDbContext _dbContext;
        public CategoryService()
        {

        }
        public CategoryService(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoryEntities = await _dbContext.Categories
                                    .Include(a => a.Children)
                                    .ToListAsync();
            var result = new List<CategoryDto>();
            foreach (var entity in categoryEntities)
            {
                CategoryDto category = MapCategoryToDto(entity);
                result.Add(category);
            }
            return result;
        }

        public async Task<ArticleDto> UpdateArticleById(ArticleDto updatedArticle)
        {
            throw new NotImplementedException();
        }

        private CategoryDto MapCategoryToDto(Category entity)
        {
            CategoryDto result = new CategoryDto
            {
                Id = entity.Id,
                Alias = entity.Alias,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate,
                LastModifiedDate = entity.LastModifiedDate,
                Articles = null,
                SubCategories = entity.Children.Select(c=>new CategoryDto{
                    Id=c.Id,
                    Alias=c.Alias,
                    Description = c.Description,
                    CreatedDate = c.CreatedDate,
                    LastModifiedDate = c.LastModifiedDate
                })
            };
            return result;
        }
    }
}
