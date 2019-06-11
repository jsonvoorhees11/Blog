using System;
using System.Collections.Generic;
using Blog.DataAccess.Entities;

namespace Blog.DataAccess.Seeding{
    public class DataSeedingFromJsonDto{
        public IEnumerable<Article> Articles{get;set;}
        public IEnumerable<ArticleCategory> ArticleCategories{get;set;}
        public IEnumerable<ArticleTag> ArticleTags{get;set;}
        public IEnumerable<Category> Categories{get;set;}
        public IEnumerable<Comment> Comments{get;set;}
        public IEnumerable<Reader> Readers{get;set;}
        public IEnumerable<Tag> Tags{get;set;}
        public IEnumerable<User> Users{get;set;}
        

    }
}