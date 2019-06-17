using System;
using System.Collections.Generic;
using Blog.Models;
using Blog.DataAccess.Repositories;
using Blog.DataAccess.Entities;
using Blog.Mappers;
using Blog.DataAccess;
using System.Linq;

namespace Blog.Services
{
    public class ArticleService : IArticleService
    {
        private readonly BlogDbContext _dbContext;
        private readonly IMapper<Article, ArticleDto> _mapper;
        public ArticleService(){

        }
        public ArticleService(BlogDbContext dbContext, IMapper<Article, ArticleDto> mapper){
            _dbContext = dbContext;
            _mapper = mapper;
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

        public IEnumerable<ArticleDto> GetArticles()
        {
            var articleEntities = _dbContext.Articles.ToList();
            var articleDtos = _mapper.MapEntityToDto(articleEntities);
            return articleDtos;
        }

        public ArticleDto UpdateArticleById(ArticleDto updatedArticle)
        {
            throw new NotImplementedException();
        }
    }
}
