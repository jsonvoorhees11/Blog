using System;
using System.Collections.Generic;
namespace Blog.Models{
    public class CategoryDto{
        public string Id { get; set; }
        public string Alias{get;set;}
        public string Description { get; set; }
        public string ParentId{get;set;}
        public IEnumerable<ArticleDto> Articles { get; set; }
        public CategoryDto ParentCategory { get; set; }
        public IEnumerable<CategoryDto> SubCategories{get;set;}
        public long CreatedDate { get; set; }
        public long LastModifiedDate { get; set; }
    }
}
