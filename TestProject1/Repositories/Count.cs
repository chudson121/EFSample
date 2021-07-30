using System.Linq;
using System.Threading.Tasks;
using EFSample;
using TechRadar.Infrastructure.Tests.Data;
using Xunit;

namespace TestProject1.Repositories
{
    [Collection("ContextFixture")]
    [Trait("Category", "TripleDerbyRepository")]
    public class Count : ApplicationRepositoryTestBase
    {
        public Count(ContextFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ItReturnsCount()
        {
            // Arrange
            // Act
            var count = await Repository.Count<Company>();

            // Assert
            Assert.IsAssignableFrom<int>(count);
            Assert.Equal(Context.Companies.Count(), count);
        }
    }
}