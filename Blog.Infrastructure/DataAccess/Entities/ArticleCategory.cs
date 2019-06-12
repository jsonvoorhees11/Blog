using System;
using Newtonsoft.Json;

namespace Blog.DataAccess.Entities{
    public class ArticleCategory{
        public string ArticleId{get;set;}
        
        public Article Article{get;set;}
        public string CategoryId{get;set;}
        
        public Category Category{get;set;}
    }
}
