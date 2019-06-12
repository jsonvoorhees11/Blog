using System;
using Microsoft.EntityFrameworkCore;
using Blog.DataAccess.Entities;
using Blog.DataAccess.Constants;
using Blog.DataAccess.Seeding;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Blog.DataAccess
{
    public class BlogDbContext : IdentityDbContext
    {
        private readonly IDataSeeding _dataSeeding;
        public BlogDbContext(IDataSeeding dataSeeding, DbContextOptions<BlogDbContext> options):base(options)
        {
            _dataSeeding = dataSeeding;

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticleCategory>(articleCategory =>
            {
                articleCategory.HasKey(ac => new { ac.ArticleId, ac.CategoryId });
                articleCategory.HasOne(ac => ac.Article)
                    .WithMany(a => a.ArticleCategories)
                    .HasForeignKey(ac => ac.ArticleId);
                articleCategory.HasOne(ac => ac.Category)
                .WithMany(a => a.ArticleCategories)
                .HasForeignKey(ac => ac.CategoryId);
                
                articleCategory.HasData(_dataSeeding.GetArticleCategories());
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

                articleTag.HasData(_dataSeeding.GetArticleTags());
            });

            modelBuilder.Entity<Article>(article =>
            {
                article.HasKey(m => m.Id);
                article.Property(m=>m.Id).ValueGeneratedOnAdd();
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

                article.HasData(_dataSeeding.GetArticles());
            });

            modelBuilder.Entity<Category>(category=>{
                category.HasKey(c=>c.Id);
                category.Property(c=>c.Id).ValueGeneratedOnAdd();
                category.HasAlternateKey(c=>c.Alias)
                .HasName("Unique_Alias");
                category.Property(c=>c.Description).IsRequired();
                category.Property(c=>c.Name).IsRequired();
                category.Property(c=>c.CreatedDate)
                        .HasDefaultValue(TimeConstants.EpochStart);
                category.Property(c=>c.LastModifiedDate)
                        .HasDefaultValue(TimeConstants.EpochStart);
                category.HasOne(c=>c.Parent)
                        .WithMany(pc=>pc.Children)
                        .HasForeignKey(c=>c.ParentId);

                category.HasData(_dataSeeding.GetCategories());
            });

            modelBuilder.Entity<Comment>(comment=>{
                comment.HasKey(c=>c.Id);
                comment.Property(c=>c.Id).ValueGeneratedOnAdd();
                comment.HasOne(c=>c.Reader)
                        .WithMany(r=>r.Comments)
                        .HasForeignKey(c=>c.ReaderId);
                comment.HasOne(c=>c.Article)
                        .WithMany(a=>a.Comments)
                        .HasForeignKey(c=>c.ArticleId);
                comment.Property(c=>c.CreatedDate)
                        .HasDefaultValue(TimeConstants.EpochStart);

                comment.HasData(_dataSeeding.GetComments());        
                
            });

            modelBuilder.Entity<Reader>(reader=>{
                reader.HasKey(r=>r.Id);
                reader.Property(c=>c.Id).ValueGeneratedOnAdd();
                reader.Property(r=>r.Name).IsRequired();
                reader.Property(r=>r.IpAddress).IsRequired();

                reader.HasData(_dataSeeding.GetReaders());
            });

            modelBuilder.Entity<Tag>(tag=>{
                tag.HasKey(t=>t.Id);
                tag.Property(c=>c.Id).ValueGeneratedOnAdd();
                tag.HasAlternateKey(t=>t.Alias).HasName("Unique_Alias");
                tag.Property(t=>t.CreatedDate)
                        .HasDefaultValue(TimeConstants.EpochStart);
                try{
                    tag.HasData(_dataSeeding.GetTags());
                }
                catch(Exception ex){
                    Console.WriteLine(JsonConvert.SerializeObject(_dataSeeding.GetTags()));
                    Console.WriteLine(ex.StackTrace);
                    throw;
                }
            });

            modelBuilder.Entity<User>(user =>
            {
                user.Property(m => m.CreatedDate)
                    .HasDefaultValue(TimeConstants.EpochStart);
                user.Property(m => m.LastModifiedDate)
                        .HasDefaultValue(TimeConstants.EpochStart);

                user.HasData(_dataSeeding.GetUsers());
            });

        }
    }
}
