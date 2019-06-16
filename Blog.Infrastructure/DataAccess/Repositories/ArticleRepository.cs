using System;
using Blog.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess.Repositories{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository{
        private readonly BlogDbContext _dbContext;
        private readonly DbSet<Article> _table;
        public ArticleRepository(BlogDbContext dbContext) : base(dbContext)
        {
            
        }

    }
}
