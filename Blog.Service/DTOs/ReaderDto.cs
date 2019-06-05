using System;
using System.Collections.Generic;
namespace Blog.Models{
    public class ReaderDto{
        public string Name { get; set; }
        public string IpAddress { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }
    }
}