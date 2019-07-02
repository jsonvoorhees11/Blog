using System;
using System.Collections;
using System.Collections.Generic;

namespace Blog.Models
{
    public class ArticleFilterDto{
        public IEnumerable<string> CategoryIds { get; set; }
        public IEnumerable<string> TagIds{get;set;}
        
    }
    
}
