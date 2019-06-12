using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Blog.DataAccess.Entities
{
    public class Comment{
        public string Id { get; set; }
        public string Recap { get; set; }
        public string Content{get;set;}
        public long CreatedDate { get; set; }
        
        public string ArticleId{get;set;}
        public string ReaderId{get;set;}
        

        public Article Article{get;set;}
        
        public Reader Reader{get;set;}

    }
    
}
