using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class CommentDto{
        public string Id { get; set; }
        public string Recap { get; set; }
        public string Content{get;set;}
        public IEnumerable<CommentDto> ChildComments { get; set; }
        public CommentDto ParentComment{get;set;}
        public ReaderDto Commentator{get;set;} 
        public long CreatedDate { get; set; }
        
    }
    
}