using System;
using System.Collections.Generic;

namespace Blog.DataAccess.Entities
{
    public class Article
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string Recap { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }

        public long CreatedDate { get; set; }
        public long LastModifiedDate { get; set; }

    }
}