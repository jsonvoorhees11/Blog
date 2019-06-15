using Xunit;
using Blog.DataAccess.Seeding;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Blog.DataAccess.Entities;
using System;

namespace Blog.Test
{
    public class DataSeedingUnitTest
    {
        public DataSeedingUnitTest()
        {
                                
        }

        [Fact]
        public void DataSeedingFromJson_ParentIdShouldBeNull_WhenParentIdBlank()
        {
            //Arrange
            var dataSourceJsonString = GetDataSeedingSourceJsonString();
            var dataSourceFromJson = JsonConvert
                                .DeserializeObject<DataSeedingFromJsonDto>(dataSourceJsonString);
            var dataSource = new DataSeedingFromJson();

            string[] categoryIdsWithBlankParentId = dataSourceFromJson.Categories
                                                    .Where(c => c.ParentId == string.Empty)
                                                    .Select(c => c.Id).ToArray();
            //Act
            var actual = dataSource.GetCategories().Where(c => categoryIdsWithBlankParentId.Contains(c.Id)).Select(p => p.ParentId).First();

            //Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("Articles")]
        [InlineData("ArticleCategories")]
        [InlineData("ArticleTags")]
        [InlineData("Categories")]
        [InlineData("Comments")]
        [InlineData("Readers")]
        [InlineData("Tags")]
        [InlineData("Users")]
        public void DataSeedingFromJson_DataMustBePopulated_WhenJsonStringValid(string propertyName){
            //Arrange
            var dataSourceJsonString = GetDataSeedingSourceJsonString();
            var dataSourceFromJson = JsonConvert
                                .DeserializeObject<DataSeedingFromJsonDto>(dataSourceJsonString);
            var dataSource = new DataSeedingFromJson().Data;
            
            //Act
            var property = dataSource.GetType().GetProperty(propertyName);
            var propertyValue = property.GetValue(dataSource,null);

            //Assert
            Assert.NotNull(propertyValue);
        }

        #region Get json string of seeding data
        private string GetDataSeedingSourceJsonString()
        {
            return
            @"{
                ""articles"":[
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
                ],
                ""articleCategories"":[
                    {
                        ""articleId"":""9a574346-a3a5-4860-a3bd-54be358ba236"",
                        ""categoryId"":""15838af4-3566-4438-a7fa-5dbc2d97af80""
                    },
                    {
                        ""articleId"":""47eef876-5eb2-442f-913c-6ad098864f9e"",
                        ""categoryId"":""15838af4-3566-4438-a7fa-5dbc2d97af80""
                    },
                    {
                        ""articleId"":""f2e240c4-3e7e-4c87-93ce-c95ffa2941c2"",
                        ""categoryId"":""15838af4-3566-4438-a7fa-5dbc2d97af80""
                    },
                    {
                        ""articleId"":""f2e240c4-3e7e-4c87-93ce-c95ffa2941c2"",
                        ""categoryId"":""f9e04123-f0c7-404f-b7bd-c0c03db0e5c3""
                    },
                    {
                        ""articleId"":""4bcfe398-d377-43ce-a134-99f0823511d7"",
                        ""categoryId"":""f9e04123-f0c7-404f-b7bd-c0c03db0e5c3""
                    }
                ],
                ""articleTags"":[
                    {
                        ""articleId"":""9a574346-a3a5-4860-a3bd-54be358ba236"",
                        ""tagId"":""3a045768-5dfc-4a46-b673-7d10f7da6ee8""
                    },
                    {
                        ""articleId"":""9a574346-a3a5-4860-a3bd-54be358ba236"",
                        ""tagId"":""5a10c508-b548-42e7-a968-a487b66c6984""
                    },
                    {
                        ""articleId"":""9a574346-a3a5-4860-a3bd-54be358ba236"",
                        ""tagId"":""46a0b627-93c7-4b95-a029-b788ad887b1e""
                    },
                    {
                        ""articleId"":""47eef876-5eb2-442f-913c-6ad098864f9e"",
                        ""tagId"":""5a10c508-b548-42e7-a968-a487b66c6984""
                    },
                    {
                        ""articleId"":""4bcfe398-d377-43ce-a134-99f0823511d7"",
                        ""tagId"":""3a045768-5dfc-4a46-b673-7d10f7da6ee8""
                    },
                    {
                        ""articleId"":""4bcfe398-d377-43ce-a134-99f0823511d7"",
                        ""tagId"":""46a0b627-93c7-4b95-a029-b788ad887b1e""
                    },
                    {
                        ""articleId"":""f2e240c4-3e7e-4c87-93ce-c95ffa2941c2"",
                        ""tagId"":""5a10c508-b548-42e7-a968-a487b66c6984""
                    }
                ],
                ""categories"":[
                    {
                        ""id"":""15838af4-3566-4438-a7fa-5dbc2d97af80"",
                        ""alias"":""NET-FRAMEWORK"",
                        ""name"":"".NET/.NET Core Framework"",
                        ""description"":""Articles about the .NET/.NET Core framework"",
                        ""parentId"":""289ebc79-5307-4c89-ac1b-025a780eaa73"",
                        ""createdDate"":""1560182949"",
                        ""lastModifiedDate"":""1560182949""
                    },
                    {
                        ""id"":""f9e04123-f0c7-404f-b7bd-c0c03db0e5c3"",
                        ""alias"":""JAVASCRIPT"",
                        ""name"":""Javascript"",
                        ""description"":""Articles about Javascript and its libraries"",
                        ""parentId"":""289ebc79-5307-4c89-ac1b-025a780eaa73"",
                        ""createdDate"":""1560182949"",
                        ""lastModifiedDate"":""1560182949""
                    },
                    {
                        ""id"":""289ebc79-5307-4c89-ac1b-025a780eaa73"",
                        ""alias"":""TECHNICAL"",
                        ""name"":""Technical"",
                        ""description"":""Articles about technical topics"",
                        ""parentId"":"""",
                        ""createdDate"":""1560182949"",
                        ""lastModifiedDate"":""1560182949""
                    }
                ],
                ""comments"":[
                    {
                        ""id"":""a4668006-e3f5-4038-a852-6c764913a976"",
                        ""recap"":""This article is useful"",
                        ""content"":""Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam"",
                        ""createdDate"":""1560182949"",
                        ""articleId"":""47eef876-5eb2-442f-913c-6ad098864f9e"",
                        ""readerId"":""c4fa13de-f446-411c-9ed9-d6a5119b7b96""
                    },
                    {
                        ""id"":""351ecc42-2de5-4835-bdb4-dc0da4233acc"",
                        ""recap"":""It's basic"",
                        ""content"":""Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain"",
                        ""createdDate"":""1560182949"",
                        ""articleId"":""9a574346-a3a5-4860-a3bd-54be358ba236"",
                        ""readerId"":""27fe5a64-0032-4d11-9225-ecc9d54b8a52""
                    },
                    {
                        ""id"":""4306d506-b505-4581-886f-016eda2bcfa9"",
                        ""recap"":""I prefer Angular"",
                        ""content"":""Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis"",
                        ""createdDate"":""1560182949"",
                        ""articleId"":""47eef876-5eb2-442f-913c-6ad098864f9e"",
                        ""readerId"":""27fe5a64-0032-4d11-9225-ecc9d54b8a52""
                    }
                    
                ],
                ""readers"":[
                    {
                        ""id"":""27fe5a64-0032-4d11-9225-ecc9d54b8a52"",
                        ""name"":""Xiao Qin Fang"",
                        ""ipAddress"":""10.125.21.2""
                    },
                    {
                        ""id"":""c4fa13de-f446-411c-9ed9-d6a5119b7b96"",
                        ""name"":""Raccoon"",
                        ""ipAddress"":""120.22.31.55""
                    }
                ],
                ""users"":[
                    {
                        ""id"":""87913df7-7dc9-45bb-a486-6be3a902f8c0"",
                        ""email"":""lolgag@9gag.com"",
                        ""createdDate"":""1560182949"",
                        ""lastModifiedDate"":""1560182949""
                    },
                    {
                        ""id"":""f6eb594c-4c06-4dec-9412-133c2d32a549"",
                        ""email"":""tech@reddit.com"",
                        ""createdDate"":""1560182949"",
                        ""lastModifiedDate"":""1560182949""
                    }
                ],
                ""tags"":[
                    {
                        ""id"":""3a045768-5dfc-4a46-b673-7d10f7da6ee8"",
                        ""alias"":""dotnet"",
                        ""createdDate"":""1560182949"",
                        ""lastModifiedDate"":""1560182949""
                    },
                    {
                        ""id"":""46a0b627-93c7-4b95-a029-b788ad887b1e"",
                        ""alias"":""js"",
                        ""createdDate"":""1560182949"",
                        ""lastModifiedDate"":""1560182949""
                    },
                    {
                        ""id"":""5a10c508-b548-42e7-a968-a487b66c6984"",
                        ""alias"":""technical"",
                        ""createdDate"":""1560182949"",
                        ""lastModifiedDate"":""1560182949""
                    }
                ]
            }";
        }
        #endregion
    }
}
