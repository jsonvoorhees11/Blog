using System.Collections.Generic;
using Blog.DataAccess.Entities;
using Blog.Mappers;
using Blog.Models;
using Newtonsoft.Json;
using Xunit;

namespace Blog.Test{
    public class ArticleMappingUnitTests{
        [Fact]
        public void MappingArticleToArticleDto_ShouldReturnArticleDto_WhenArticleValid()
        {
        //Arrange
            var articleJsonString = @"{""id"":""9a574346-a3a5-4860-a3bd-54be358ba236"",
                        ""title"":""How .NET compiler work?"",
                        ""slug"":""how-net-compiler-work"",
                        ""thumbnailImageUrl"":""https://localhost:7070/api/fileUploader/netcompiler.png"",
                        ""recap"":"".NET compiler is really complicated"",
                        ""content"":""I don't know how it works either"",
                        ""createdDate"": ""1560182949"",
                        ""lastModifiedDate"":""1560182949"",
                        ""authorId"":""f6eb594c-4c06-4dec-9412-133c2d32a549""}";

            var userJsonString = @"{""id"":""87913df7-7dc9-45bb-a486-6be3a902f8c0"",
                        ""email"":""lolgag@9gag.com"",      
                        ""createdDate"":""1560182949"",     
                        ""lastModifiedDate"":""1560182949""}";  

            var article = JsonConvert.DeserializeObject<Article>(articleJsonString);
            var user = JsonConvert.DeserializeObject<User>(userJsonString);
            var articleMapper = new ArticleMapper(user);
            var expected = new ArticleDto{
                Id="9a574346-a3a5-4860-a3bd-54be358ba236",
                Slug="how-net-compiler-work",
                ThumbnailImageUrl = "https://localhost:7070/api/fileUploader/netcompiler.png",
                Recap = ".NET compiler is really complicated",
                Content="I don't know how it works either",
                CreatedDate=1560182949,
                LastModifiedDate=1560182949,
                Author= new UserDto { Id = user.Id, Email = user.Email, CreatedDate = user.CreatedDate},
                Comments = new List<CommentDto>()
            }; 
        //Act
            var actual = articleMapper.MapEntityToDto(article);

        //Assert
            Assert.Equal(expected.Author.Id, actual.Author.Id);

        }
    }
}
