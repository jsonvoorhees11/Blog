using System;
using System.Collections.Generic;
using System.IO;
using Blog.DataAccess.Entities;
using Blog.DataAccess.Constants;
using Newtonsoft.Json;
using System.Linq;

namespace Blog.DataAccess.Seeding
{
    public class DataSeedingFromJson : IDataSeeding
    {
        public DataSeedingFromJsonDto Data;

        public DataSeedingFromJson()
        {
            string folderPath = Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            folderPath = folderPath.Split(':')[1];
            string filePath = Path.Combine(folderPath, "data-for-seeding.json");
            string dataJsonString = File.ReadAllText(filePath);

            Data = JsonConvert.DeserializeObject<DataSeedingFromJsonDto>(dataJsonString);
            IEnumerable<Category> categories = Data.Categories.Select(c=>{
                if(string.IsNullOrEmpty(c.ParentId))
                {
                    c.ParentId = null;
                }
                return c;
            });
            Data.Categories = categories;
        }
        public IEnumerable<Article> GetArticles()
        {
            return Data.Articles;
        }
        public IEnumerable<ArticleCategory> GetArticleCategories()
        {
            return Data.ArticleCategories;
        }
        public IEnumerable<ArticleTag> GetArticleTags()
        {
            return Data.ArticleTags;
        }
        public IEnumerable<Category> GetCategories()
        {
            return Data.Categories;
        }
        public IEnumerable<Comment> GetComments()
        {
            return Data.Comments;
        }
        public IEnumerable<Reader> GetReaders()
        {
            return Data.Readers;
        }
        public IEnumerable<Tag> GetTags()
        {
            return Data.Tags;
        }
        public IEnumerable<User> GetUsers()
        {
            return Data.Users;
        }
    }
}
