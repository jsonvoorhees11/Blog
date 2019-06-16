using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Blog.DataAccess.Entities
{
    public class Article
    {
        public Article()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Article(string id){
            Id=id;
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string Recap { get; set; }
        public string Content { get; set; }

        public long CreatedDate { get; set; }
        public long LastModifiedDate { get; set; }
        public string AuthorId{get;set;}
        
        public User Author{get;set;}
        
        public IEnumerable<ArticleTag> ArticleTags {get;set;}
        
        public IEnumerable<Comment> Comments {get;set;}
        
        public IEnumerable<ArticleCategory> ArticleCategories{get;set;}

    }
}
