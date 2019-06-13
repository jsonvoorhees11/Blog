using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace Blog.DataAccess.Entities
{
    public class User : IdentityUser<string>
    {
        public long CreatedDate { get; set; }
        public long LastModifiedDate { get; set; }

        
        public IEnumerable<Article> Articles {get;set;}

    }
}
