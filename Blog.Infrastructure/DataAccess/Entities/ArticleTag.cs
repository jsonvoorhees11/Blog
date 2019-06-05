using System;

namespace Blog.DataAccess.Entities{
    public class ArticleTag{
        public string ArticleId{get;set;}
        public Article Article{get;set;}
        public string TagId{get;set;}
        public Tag Tag{get;set;}
    }
}