using System;
using System.Collections.Generic;
namespace Blog.DataAccess.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        
        public long CreatedDate { get; set; }
        public long LastModifiedDate { get; set; }

    }
}