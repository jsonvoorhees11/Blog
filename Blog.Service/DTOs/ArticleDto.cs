using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class ArticleDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string Recap { get; set; }
        public string Content { get; set; }
        public UserDto Author{get;set;}
        public IEnumerable<CategoryDto> Categories{get;set;}
        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }

        public long CreatedDate { get; set; }
        public long LastModifiedDate { get; set; }

    }
}