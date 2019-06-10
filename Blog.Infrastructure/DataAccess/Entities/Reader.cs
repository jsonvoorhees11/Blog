using System;
using System.Collections.Generic;
namespace Blog.DataAccess.Entities{
    public class Reader{
        public string Id{get;set;}
        public string Name { get; set; }
        public string IpAddress { get; set; }

        public IEnumerable<Comment> Comments {get;set;}
    }
}