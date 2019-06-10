using System;
using System.Collections.Generic;
using Blog.DataAccess.Entities;
using Newtonsoft.Json;

namespace Blog.DataAccess.Seeding{
    public class DataSeedingFromJson : IDataSeeding {
        public IEnumerable<Article> GetArticles(){
            return new List<Article>();
        }
        public IEnumerable<ArticleCategory> GetArticleCategories(){
            throw new NotImplementedException();
        }
        public IEnumerable<ArticleTag> GetArticleTags(){
            throw new NotImplementedException();
        }
        public IEnumerable<Category> GetCategories(){
            throw new NotImplementedException();
        }
        public IEnumerable<Comment> GetComments(){
            throw new NotImplementedException();
        }
        public IEnumerable<Reader> Readers(){
            throw new NotImplementedException();
        }
        public IEnumerable<Tag> GetTags(){
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetUsers(){
            throw new NotImplementedException();
        }
    }
}