using System;
using System.Collections.Generic;
using System.Linq;
using Blog.DataAccess;
using Blog.DataAccess.Entities;
using Blog.DataAccess.Repositories;
using Blog.DataAccess.Seeding;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Blog.Test{
    public class ArticleRepositoryUnitTests
    {

        [Fact]
        public void GetAllArticles_ShouldReturnAllArticle(){
            //Arrange
            IArticleRepository articleRepository = GetInMemoryArticleRepository();    
            int expectedArticleCount = GetArticles().Count();

            //Act
            int actualArticleCount = articleRepository.GetAll().Count();

            //Assert
            Assert.Equal(expectedArticleCount, actualArticleCount);
            
        }

        private IArticleRepository GetInMemoryArticleRepository(){
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                            .UseInMemoryDatabase(databaseName: "InMemory_Articles")
                            .Options;                                
            var articles = GetArticles();
            var dataSeedingMock = new Mock<IDataSeeding>();
            dataSeedingMock.Setup(d=>d.GetArticles()).Returns(articles);
            dataSeedingMock.Setup(d=>d.GetArticleCategories()).Returns(new List<ArticleCategory>());
            dataSeedingMock.Setup(d=>d.GetArticleTags()).Returns(new List<ArticleTag>());
            dataSeedingMock.Setup(d=>d.GetCategories()).Returns(new List<Category>());
            dataSeedingMock.Setup(d=>d.GetComments()).Returns(new List<Comment>());
            dataSeedingMock.Setup(d=>d.GetReaders()).Returns(new List<Reader>());
            dataSeedingMock.Setup(d=>d.GetTags()).Returns(new List<Tag>());
            dataSeedingMock.Setup(d=>d.GetUsers()).Returns(new List<User>());

            BlogDbContext blogDbContext = new BlogDbContext(dataSeedingMock.Object, options);
            blogDbContext.Database.EnsureDeleted();
            blogDbContext.Database.EnsureCreated();
            blogDbContext.SaveChanges();
            return new ArticleRepository(blogDbContext);
            
        }

        private IEnumerable<Article> GetArticles(){
            const string articlesJsonString = @"[
                    {
                        ""id"":""9a574346-a3a5-4860-a3bd-54be358ba236"",
                        ""title"":""How .NET compiler work?"",
                        ""slug"":""how-net-compiler-work"",
                        ""thumbnailImageUrl"":""https://localhost:7070/api/fileUploader/netcompiler.png"",
                        ""recap"":"".NET compiler is really complicated"",
                        ""content"":""I don't know how it works either"",
                        ""createdDate"": ""1560182949"",
                        ""lastModifiedDate"":""1560182949"",
                        ""authorId"":""f6eb594c-4c06-4dec-9412-133c2d32a549""
                    },
                    {
                        ""id"":""47eef876-5eb2-442f-913c-6ad098864f9e"",
                        ""title"":""Angular, ReactJS and VueJs, which to choose?"",
                        ""slug"":""angular-reactjs-and-vuejs-which-to-choose"",
                        ""thumbnailImageUrl"":""https://localhost:7070/api/fileUploader/angular-is-the-best.png"",
                        ""recap"":""Angular definitely"",
                        ""content"":""Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit"",
                        ""createdDate"": ""1560182949"",
                        ""lastModifiedDate"":""1560182949"",
                        ""authorId"":""87913df7-7dc9-45bb-a486-6be3a902f8c0""
                    },
                    {
                        ""id"":""f2e240c4-3e7e-4c87-93ce-c95ffa2941c2"",
                        ""title"":""The rise of .NET Core"",
                        ""slug"":""the-rise-of-net-core"",
                        ""thumbnailImageUrl"":""https://localhost:7070/api/fileUploader/netcore.png"",
                        ""recap"":"".NET Core is sky-rocketing"",
                        ""content"":""At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga"",
                        ""createdDate"": ""1560182949"",
                        ""lastModifiedDate"":""1560182949"",
                        ""authorId"":""f6eb594c-4c06-4dec-9412-133c2d32a549""
                    },
                    {
                        ""id"":""4bcfe398-d377-43ce-a134-99f0823511d7"",
                        ""title"":""Rust is becoming another trend"",
                        ""slug"":""rust-is-becoming-another-trend"",
                        ""thumbnailImageUrl"":""https://localhost:7070/api/fileUploader/rustland.png"",
                        ""recap"":""Rust is becoming another trend"",
                        ""content"":""Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur"",
                        ""createdDate"": ""1560182949"",
                        ""lastModifiedDate"":""1560182949"",
                        ""authorId"":""f6eb594c-4c06-4dec-9412-133c2d32a549""
                    }
                ]";
            
            var articles = JsonConvert.DeserializeObject<IEnumerable<Article>>(articlesJsonString);
            return articles;
        }

    }
}
