using System;
using Microsoft.EntityFrameworkCore;
using Blog.DataAccess.Entities;

namespace Blog.DataAccess{
    public class BlogDbContext:DbContext{
        public DbSet<Article> Articles{get;set;}
        
    }
}