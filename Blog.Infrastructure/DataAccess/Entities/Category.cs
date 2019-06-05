using System;
using System.Collections.Generic;
namespace Blog.DataAccess.Entities{
    public class Category{
        public string Id { get; set; }
        public string Alias{get;set;}
        public string Description { get; set; }
        public string ParentCategoryId { get; set; }
        public long CreatedDate { get; set; }
        public long LastModifiedDate { get; set; }

        public IEnumerable<ArticleCategory> ArticleCategories { get; set; }
    }
}