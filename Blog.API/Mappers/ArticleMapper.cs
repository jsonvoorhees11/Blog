using System;
using System.Collections.Generic;
using System.Linq;
using Blog.DataAccess;
using Blog.DataAccess.Entities;
using Blog.Models;

namespace Blog.Mappers{
    public class ArticleMapper : IMapper<Article, ArticleDto>{
        private User _user;
        public ArticleMapper()
        {
            
        }
        public ArticleMapper(User user){
            _user = user;
        }
        public ArticleDto MapEntityToDto(Article entity){
            ArticleDto dto = new ArticleDto(){
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                ThumbnailImageUrl = entity.ThumbnailImageUrl,
                Recap = entity.Recap,
                Content = entity.Content,
                CreatedDate = entity.CreatedDate,
                LastModifiedDate = entity.LastModifiedDate,
                Author = new UserDto{
                     Email = _user.Email,
                     Id = _user.Id,
                     CreatedDate = _user.CreatedDate
                }
            };
            return dto;
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
