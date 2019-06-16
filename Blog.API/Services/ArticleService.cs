using System;
using System.Collections.Generic;
using Blog.Models;
using Blog.DataAccess.Repositories;
using Blog.DataAccess.Entities;
using Blog.Mappers;
namespace Blog.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper<Article, ArticleDto> _mapper;
        public ArticleService(){

        }
        public ArticleService(IArticleRepository repo, IMapper<Article, ArticleDto> mapper){
            _repository = repo;
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
            return new List<ArticleDto>();
        }

        public ArticleDto UpdateArticleById(ArticleDto updatedArticle)
        {
            throw new NotImplementedException();
        }
    }
}
