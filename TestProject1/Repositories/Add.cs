using System.Threading.Tasks;
using EFSample;
using TechRadar.Infrastructure.Tests.Data;
using Xunit;

namespace TestProject1.Repositories
{
    [Collection("ContextFixture")]
    [Trait("Category", "TechRadarRepository")]
    public class Add : ApplicationRepositoryTestBase
    {
        public Add(ContextFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ItAddsItem()
        {
            // Arrange
            var item = new Company();

            // Act
            await Repository.Add(item);

            // Assert
            Assert.Contains(Context.Companies, x => x == item);
        }

        [Fact]
        public async Task ItReturnsNewlyAddedItem()
        {
            // Arrange
            var item = new Company();

            // Act
            var newlyAddedItem = await Repository.Add(item);

            // Assert
            Assert.Equal(item, newlyAddedItem);
        }
    }
}