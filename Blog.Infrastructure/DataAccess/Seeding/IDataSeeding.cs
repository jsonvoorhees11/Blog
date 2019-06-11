using System;
using System.Collections.Generic;
using Blog.DataAccess.Entities;

namespace Blog.DataAccess.Seeding{
    public interface IDataSeeding {
        IEnumerable<Article> GetArticles();
        IEnumerable<ArticleCategory> GetArticleCategories();
        IEnumerable<ArticleTag> GetArticleTags();
        IEnumerable<Category> GetCategories();
        IEnumerable<Comment> GetComments();
        IEnumerable<Reader> GetReaders();
        IEnumerable<Tag> GetTags();
        IEnumerable<User> GetUsers();
    }
}