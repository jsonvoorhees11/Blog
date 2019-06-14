using Xunit;
using Blog.DataAccess.Seeding;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Blog.Test
{
    public class DataSeedingUnitTest
    {
        private DataSeedingFromJson _dataSeeding;
        private DataSeedingFromJsonDto _dataSeedingSource;
        public DataSeedingUnitTest()
        {
            _dataSeeding = new DataSeedingFromJson();
            string dataJsonFilePath = Path.Combine(Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Split(':')[1], "data-for-seeding.json");
            string dataJsonString = File.ReadAllText(dataJsonFilePath);
            _dataSeedingSource = JsonConvert.DeserializeObject<DataSeedingFromJsonDto>(dataJsonString);
        }

        [Fact]
        public void DataSeedingFromJson_ParentIdShouldBeNull_WhenParentIdBlank()
        {
            //Arrange
            string[] categoryIdsWithBlankParentId = _dataSeedingSource.Categories
                                                    .Where(c=>c.ParentId==string.Empty)
                                                    .Select(c=>c.Id).ToArray();

            //Act
            var result = _dataSeeding.GetCategories().Where(c=>categoryIdsWithBlankParentId.Contains(c.Id));

            //Assert
            Assert.NotNull(result);
        }
    }
}
