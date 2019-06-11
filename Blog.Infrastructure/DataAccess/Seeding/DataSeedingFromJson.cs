using System;
using System.Collections.Generic;
using System.IO;
using Blog.DataAccess.Entities;
using Blog.DataAccess.Constants;
using Newtonsoft.Json;

namespace Blog.DataAccess.Seeding{
    public class DataSeedingFromJson : IDataSeeding {
        public DataSeedingFromJsonDto Data;

        public DataSeedingFromJson()
        {
            string dataJsonString = File.ReadAllText(FilePathConstants.DataSeeding);
            Data = JsonConvert.DeserializeObject<DataSeedingFromJsonDto>(dataJsonString);
        }
        public IEnumerable<Article> GetArticles(){
            return Data.Articles;
        }
        public IEnumerable<ArticleCategory> GetArticleCategories(){
            return Data.ArticleCategories;
        }
        public IEnumerable<ArticleTag> GetArticleTags(){
            return Data.ArticleTags;
        }
        public IEnumerable<Category> GetCategories(){
            return Data.Categories;
        }
        public IEnumerable<Comment> GetComments(){
            return Data.Comments;
        }
        public IEnumerable<Reader> GetReaders(){
            return Data.Readers;
        }
        public IEnumerable<Tag> GetTags(){
            return Data.Tags;
        }
        public IEnumerable<User> GetUsers(){
            return Data.Users;
        }
    }
}