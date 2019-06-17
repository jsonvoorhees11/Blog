using System;
using System.Collections.Generic;
using Blog.DataAccess.Entities;
using Blog.Models;

namespace Blog.Mappers{
    public class ArticleMapper : IMapper<Article, ArticleDto>{
        public ArticleMapper()
        {
        }
        public ArticleDto MapEntityToDto(Article entity){
            return new ArticleDto();
        }
        public Article MapDtoToEntity(ArticleDto dto){
            return new Article();
        }
        public IEnumerable<ArticleDto> MapEntityToDto(IEnumerable<Article> articleEntities){
            return new List<ArticleDto>();
        }
        public IEnumerable<Article> MapDtoToEntity(IEnumerable<ArticleDto> articleEntities){
            return new List<Article>();
        }

    }
}
