using System;
using System.Collections.Generic;

namespace Blog.DataAccess.Entities
{
    public class Comment{
        public string Id { get; set; }
        public string Recap { get; set; }
        public string Content{get;set;}
        public long CreatedDate { get; set; }
        
    }
    
}