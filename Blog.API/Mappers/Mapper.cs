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
    }
}
