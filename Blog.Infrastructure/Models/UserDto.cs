using System;
using System.Collections.Generic;
namespace Blog.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ArticleDto> WrittenArticles { get; set; }
        
        public long CreatedDate { get; set; }
        public long LastModifiedDate { get; set; }

    }
}