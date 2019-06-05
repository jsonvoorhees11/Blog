using System;
using System.Collections.Generic;
namespace Blog.Models{
    public class TagDto{
        public string Id { get; set; }
        public string Alias { get; set; }
        public long CreatedDate { get; set; }
        public long LastModifiedDate { get; set; }
    }
}