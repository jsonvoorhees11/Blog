using System;
using Microsoft.EntityFrameworkCore;
using Blog.DataAccess.Entities;
using Blog.DataAccess.Constants;

namespace Blog.DataAccess
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleCategory>(articleCategory =>
            {
                articleCategory.HasKey(ac => new { ac.ArticleId, ac.CategoryId });
                articleCategory.HasOne(ac => ac.Article)
                    .WithMany(a => a.ArticleCategories)
                    .HasForeignKey(ac => ac.ArticleId);
                articleCategory.HasOne(ac => ac.Category)
                .WithMany(a => a.ArticleCategories)
                .HasForeignKey(ac => ac.CategoryId);
            });

            modelBuilder.Entity<ArticleTag>(articleTag =>
            {
                articleTag.HasKey(ac => new { ac.ArticleId, ac.TagId });
                articleTag.HasOne(ac => ac.Article)
                    .WithMany(a => a.ArticleTags)
                    .HasForeignKey(ac => ac.ArticleId);
                articleTag.HasOne(ac => ac.Tag)
                .WithMany(a => a.ArticleTags)
                .HasForeignKey(ac => ac.TagId);
            });

            modelBuilder.Entity<Article>(article =>
            {
                article.HasKey(m => m.Id);
                article.Property(m => m.Title).IsRequired();
                article.Property(m => m.Slug).IsRequired();
                article
                    .HasAlternateKey(m => m.Slug)
                    .HasName("Unique_Slug");
                article.Property(m => m.CreatedDate)
                        .HasDefaultValue(TimeConstants.EpochStart);
                article.Property(m => m.LastModifiedDate)
                        .HasDefaultValue(TimeConstants.EpochStart);

                article.HasOne(m => m.Author)
                        .WithMany(n => n.Articles)
                        .HasForeignKey(m => m.AuthorId);

            });

            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(m => m.Id);
                user.HasAlternateKey(m => m.Email)
                    .HasName("Unique_Email");
                user.Property(m => m.CreatedDate)
                    .HasDefaultValue(TimeConstants.EpochStart);
                user.Property(m => m.LastModifiedDate)
                        .HasDefaultValue(TimeConstants.EpochStart);
            });



        }
    }
}